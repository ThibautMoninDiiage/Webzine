#Sauvegarde envoyer sur le serveur
#!/bin/bash
mail="xxxxx@xxxxxx.com"
hostrsync="192.168.30.252"
utilisateurrsync=sauvegarde
export RSYNC_PASSWORD=root

rsync -rlptD --stats /var/lib/docker/volumes/docker-elk-main_elasticsearch/_data $utilisateurrsync@$hostrsync::portainer
rsync -rlptD --stats /var/lib/docker/volumes/portainer_data/_data $utilisateurrsync@$hostrsync::portainer
