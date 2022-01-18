## Installation de portainer pour docker :

Création du volume : 

    docker volume create portainer_data

Téléchargement de Portainer : 

    docker run -d -p 8000:8000 -p 9443:9443 --name portainer \ --restart=always \ -v /var/run/docker.sock:/var/run/docker.sock \ -v portainer_data:/data \ cr.portainer.io/portainer/portainer-ce:2.9.3

Une fois portainer installé nous pouvons tester en tapant l'URL dans notre navigateur : 

    https://localhost:9443

