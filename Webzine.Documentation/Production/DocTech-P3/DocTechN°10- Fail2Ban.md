## Configuration de Fail2ban :


Nous téléchargeons le paquet :

    apt install fail2ban 

Copie du fichier Jail.conf :

    cp /etc/fail2ban/jail.conf /etc/fail2ban/jail.local

Modification du "jail.local" :

    [DEFAULT]
    ignoreip = 
    bantime = 21600
    findtime = 300
    maxretry = 3
    banaction = iptables-multiport
    backend = systemd

	[sshd]
	enabled = true

Nous redémarrons le service : 

    systemctl restart fail2ban

Nous pouvons nous connecter via SSH : 

    ssh quentin@IPDELAVM

Si nous loupons trois fois la saisie du mot de passe, fail2ban nous banne ! 


