## Configuration de SSH :

Création de l'utilisateur sur toutes les VMs :

    adduser quentin

Dans /etc/sudoers : 

    quentin ALL=(ALL:ALL) ALL

Dans /etc/ssh/sshd_config :

    PermitRootLogin=no
    PasswordAuthentication no

Sur notre PC : 

    ssh-keygen -t rsa

Puis :

    ssh-copy-id quentin@IPDELAVM

On redémarre le service SSH :

    systemctl restart sshd

La configuration de SSH est terminée. 

