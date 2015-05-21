# -*- coding: utf-8 -*-
"""
Created on Wed May  6 13:46:37 2015

@author: Marco
"""

import couchdb

couch = couchdb.Server()
db = couch['twitter_raw_data']
db_clean = couch['prova2']

programming_languages = [line.strip() for line in open('languages.txt')]
nations = [line.strip() for line in open('nations3.txt')]

def get_clean_document(document):
    cleaned_tweet = dict()
    cleaned_tweet["text"] = document["text"]
    cleaned_tweet["created_at"] = document["created_at"]
    cleaned_tweet["location"] = document["user"]["location"]
    cleaned_tweet["retweet_count"] = document["retweet_count"]
    cleaned_tweet["favorite_count"] = document["favorite_count"]
    return cleaned_tweet
    
for doc_id in db:
    document = db[doc_id]
    if document["lang"] == "en" or document["lang"] == "it":
        for nation in nations:
            if nation in document["user"]["location"].lower():
                for language in programming_languages:
                    if language in document["text"].lower():     
                        if language == 'python':
                            if any(word in document["text"].lower() for word in ['animal', 'snake', 'wildlife', 'monty']):
                                break
                            print(document["user"]["location"])
                        db_clean.save(get_clean_document(document))
    #db.delete(document)                 