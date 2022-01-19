## Récapitulatif :

Nous avons une machine physique : 

- Windows server 2019 
- 16GO de RAM DDR3
- intel core i5 de 6éme génération 
- SSD de 120GO & 450go 

Sur les VMs :

- SRVNGINXPROX :
	-	512 MB de RAM
	-	Debian 11
	-	1vCPU
	-	127Go en dynamique
	-	4 cartes réseaux 
- SRVDEBELK :
	- 4048MB de RAM
	- Debian 11
	- 1vCPU
	- 127Go en dynamique
	- 1 carte réseau
- SRVDEB11ZABBIX :
	- 1024 MB de RAM
	- Debian 11
	- 1vCPU
	- 127Go en dynamique
	- 1 carte réseau
- SRVDEB11SGBD :
	- 512MB de RAM 
	- Debian 11
	- 1vCPU
	- 127Go en dynamique
	- 1 carte réseau
- SRVDEB11FRONT :
	- 512MB de RAM 
	- Debian 11
	- 1vCPU
	- 127Go en dynamique
	- 1 carte réseau
- SRVDEB11WEBZINE :
	- 1024MB de RAM 
	- Debian 11
	- 1vCPU
	- 127Go en dynamique
	- 1 carte réseau
- SRVDEB11BACKUP :
	- 512MB de RAM 
	- Debian 11
	- 1vCPU
	- 127Go en dynamique
	- 3 cartes réseaux

Les mots de passe des VMs sont : 

Compte Quentin : root

Compte root : root

Compte de BDD Zabbix : Zabbix 

Compte de ElK :
	- identifiant : elastic
	- mdp : changeme

Compte de Portainer :
	- identifiant : admin
	- mdp : rootroot

Aucun mot de passe a été définit car pas assez de temps pour tout intégralement changer. Normalement, chaque mot de passe devrait être différent et un minimum complexe. Le mieux est d'utiliser un gestionnaire de mot de passe ! 
