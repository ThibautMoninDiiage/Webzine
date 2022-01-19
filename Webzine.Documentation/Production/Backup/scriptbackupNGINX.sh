#Sauvegarde envoyer sur le serveur
#!/bin/bash
mail="xxxxx@xxxxxx.com"
hostrsync="192.168.30.252"
utilisateurrsync=sauvegarde
export RSYNC_PASSWORD=root

rsync -rlptD --stats /etc/nginx/sites-enabled $utilisateurrsync@$hostrsync::reversenginx
