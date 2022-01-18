#Sauvegarde en .sql de la BDD ZABBIX
pg_dump -h localhost -U zabbix -W zabbix zabbix > /DB/backup/dump_file_SV.sql

#Sauvegarde envoyer sur le serveur
#!/bin/bash
mail="xxxxx@xxxxxx.com"
hostrsync="192.168.30.252"
utilisateurrsync=sauvegarde
export RSYNC_PASSWORD=root

rsync -rlptD --stats /DB/backup/dump_file_SV.sql $utilisateurrsync@$hostrsync::sauvegarde
