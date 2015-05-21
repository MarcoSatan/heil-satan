# -*- coding: utf-8 -*-
"""
Created on Wed May 13 23:37:22 2015

@author: Nicola
"""

import couchdb
import calendar

couch = couchdb.Server()
db_clean = couch['twitter_clean_data']
db_analysis = couch['twitter_analyzed_data']
months = list(calendar.month_abbr)
languages = [lang.strip() for lang in open('languages.txt')]
nations = dict()

with open('nations.txt') as file:
    for line in file:
        nations[line.strip().lower()] = file.readline().strip()

def get_date(document):
    date = document['created_at'].split(' ')
    return "%s-%s" % (date[-1], months.index(date[1]))

def create_analysis(doc_id):
    doc = dict()
    doc['_id'] = doc_id
    analysis = dict()
    for nation in nations.keys():
        languages_score = dict()
        for language in languages:
            languages_score[language] = 0
        analysis[nations[nation]] = languages_score
    doc['analysis'] = analysis
    return doc

def analyze_tweet(document):
    state = nations[document['location']]
    weight = int(document['retweet_count']) * 0.5 + int(document['favorite_count']) * 0.25
    doc = db_analysis.get(get_date(document))
    if doc is not None:
        for language in languages:
            if language in document['text'].lower():
                doc['analysis'][state][language] += 1 + weight
        db_analysis.save(doc)
    else:
        doc = create_analysis(get_date(document))
        for language in languages:
            if language in document['text'].lower():
                doc['analysis'][state][language] += 1 + weight
        db_analysis.save(doc)
        
for doc_id in db_clean:
    document = db_clean[doc_id]
    analyze_tweet(document)
    