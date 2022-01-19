## Déploiement Docker :

Pour déployer l'application Webzine nous demandons aux développeurs de déposer le projet dans notre repositories de Docker Hub. 

Sur notre machine Webzine Docker : 

    docker pull quentin5821/webzinewebapplication:latest

Cela récupére l'image Docker. 

Maintenant nous exécutons la commande suivante : 

    docker run -d -p 80:80 quentin5821/webzinewebapplication:latest

Maintenant sur notre navigateur : 

    http://192.168.20.253/titre?IdTitre=1#
    http://webzine-g2.g1

Cela fonctionne ! 

