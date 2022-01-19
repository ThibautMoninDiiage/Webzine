#!/bin/bash
mail="xxxxx@xxxxxx.com"
hostrsync="192.168.30.252"
utilisateurrsync=sauvegarde
export RSYNC_PASSWORD=root

rsync -az --stats tmp/ sauvegarde@192.168.30.252:/sauvegarde

