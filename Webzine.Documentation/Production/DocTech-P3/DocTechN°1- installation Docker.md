## Installation de Docker sur Debian 11 :

Nous devons faire une mise à jour de notre Debian 11 (Obligatoire) :

    apt update && apt full-upgrade -y
Ensuite nous pouvons installer les dépendances suivantes : 

    apt-get install \
    apt-transport-https \
    ca-certificates \
    curl \
    gnupg \
    lsb-release

Ajout de la clé GPG officielle de Docker : 

    curl -fsSL https://download.docker.com/linux/debian/gpg | gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

Ajout du repository Docker dans les sources :

    echo \"deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/debian \ $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

Mise à jour des sources :

    apt update

Téléchargement de docker depuis les sources :

    apt install docker-ce docker-ce-cli containerd.io
    
L'installation de Docker est finit. 

