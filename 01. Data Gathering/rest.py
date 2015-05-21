# -*- coding: utf-8 -*-
"""
Created on Sat May  9 17:23:28 2015

@author: Nicola
"""

from TwitterAPI import TwitterRestPager, TwitterAPI
import couchdb
import time

consumer_key = ''
consumer_secret = ''

access_token = ''
access_secret_token = ''

couch = couchdb.Server()
db = couch['twitter_raw_data']

languages = [line for line in open('languages.txt')]

api = TwitterAPI(consumer_key, 
                 consumer_secret, 
                 access_token, 
                 access_secret_token)
while True:
    start_time = time.time()
    r = TwitterRestPager(api, 'search/tweets', {'q':languages, 'count':100})
    for item in r.get_iterator():
        if 'text' in item:
            db.save(item)
        elif 'message' in item and item['code'] == 88:
            sleep_time = 900 - (time.time() - start_time)
            print('Request limit exceeded: %s\n' % item['message'])
            print('Going to sleep for {0}s\n'.format(sleep_time))
            time.sleep(sleep_time)
            continue