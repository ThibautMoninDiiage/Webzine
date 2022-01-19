#Sauvegarde envoyer sur le serveur
#!/bin/bash
mail="xxxxx@xxxxxx.com"
hostrsync="192.168.30.252"
utilisateurrsync=sauvegarde
export RSYNC_PASSWORD=root

rsync -rlptD --stats /etc/zabbix/zabbix_server.conf $utilisateurrsync@$hostrsync::zabbix
