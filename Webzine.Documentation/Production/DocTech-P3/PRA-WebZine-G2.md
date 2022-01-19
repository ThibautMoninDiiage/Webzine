# PRA-WebZine-G2 :


# Sommaire : 
1. [Préambule](#ddddd)
2. [Analyse des risques](#example2)
3. [Situation actuelle](#third-example)
4. [Périmetre cible](#third-example)
5. [Scénario Web](#third-example)

## Préambule :

PRA, De quoi s'agit-il ? 

Le Plan de Reprise d’Activité (PRA) d’une organisation constitue l’ensemble des « procédures documentées lui permettant de rétablir et de reprendre ses activités en s’appuyant sur des mesures temporaires adoptées pour répondre aux exigences métier habituelles après un incident ».

Un PRA, est donc un plan qui définit les contours de la reprise de tout ou partie de l’activité d’une entité des suites d’un arrêt partiel ou total de cette dernière en fonction d’objectifs de reprise définis au préalable et des modalités pour retrouver un mode de fonctionnement optimal.

Le PRA est généralement associé au Plan de Continuité d’Activité (PCA) organisation qui est défini comme étant l’ensemble « des procédures documentées permettant de répondre à un incident perturbateur, de poursuivre ou rétablir ses activités dans un délai prédéterminé »

## Analyse des risques :

Les menaces analysées sont : 

1.  Incendie ;
    
2.  Dégâts des eaux ;
    
3.  Attaque informatique ;
    
4.  Attaque physique sur les locaux ;
    
5.  Perte de Climatisation ;
    
6.  Coupure électrique ;
    
7.  Catastrophe naturelle.




D’autres menaces s’y ajoutent pour lesquelles le traitement relève de la responsabilité du service informatique.

1.  Problème matriel ;
    
2.  Corruption de données ;
    
3.  Dysfonctionnement logiciel ;
    
4.  Erreur humaine ;
    
5.  Coupure Télécom.

## Situation actuelle :

Pour offrir une pleine compréhension du tableau qui suit, je précise la terminologie employée : 

RTO : « Recovery Time Objective » est le délai de retour à l’activité envisag

RPO : « Recovery Point Objective » représente le temps de travail perdu, c’est-à-dire les données de travail qui ne seront pas récuprables sur sinistre.


| Evènement redouté | Probabilité | Impact | Niveau de risque | RTO initial | RPO initial | 
| :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: |
| Perte de la salle serveur du diiage | Faible | très fort | Fort | 1 à 3mois | 1 jour |
| Perte d’une base de données | Faible | Fort | Moyen |30 minutes à 1 jour|  1 jour | 
| Coupure du lien au réseau internet | Très Faible | Très fort | Moyen | 30 minutes à 1 jour |4h à 1 jour | 
| Perte du serveur WebZine | Moyen | Très fort | Moyen | 4h à 1 jour | 0h |
| Perte du serveur Backup | Moyen | Très fort | Moyen | 4h à 1 jour | 0h |
| Perte du serveur Zabbix | Moyen | Très fort | Moyen | 4h à 1 jour | 0h |
| Perte du serveur ELK | Moyen | Très fort | Moyen | 4h à 1 jour | 0h |
| Perte du serveur physique | Haute | Très fort | Moyen | 4h à 1 jour | 0h |

## Périmetre cible :

Dans le cadre d'un problème survenant sur notre serveur SGBD de la base de données. 
Nous appliquons les commandes suivantes afin de réinstaller la base de données sauvegardées. 

Pour rappel sur le serveur de backup nous avons l'outil rsync qui grace à une tache planaffiée sur les serveurs, récupère le dossier/fichier de configuration de chaque service. il s'exécute à 01h00 chaque jour. 

Sur le serveur de base de données nous retrouvons la config suivantes : 

	#Sauvegarde en .sql de la BDD ZABBIX
    pg_dump -h localhost -U zabbix -W zabbix zabbix > /DB/backup/dump_file_SV.sql
    
    #Sauvegarde envoyer sur le serveur
    #!/bin/bash
    hostrsync="192.168.30.252"
    utilisateurrsync=sauvegarde
    export RSYNC_PASSWORD=root
    
    rsync -rlptD --stats /DB/backup/dump_file_SV.sql $utilisateurrsync@$hostrsync::sauvegarde

Pour restaurer la base de données nous pouvons utiliser la commande suivante : 

```default
pg_restore -U zabbix -d dump_file_SV.sql -1 zabbixsql.dump
```

Ensuite concernant les autres fichier de configuration nous faisons l'inverse des sauvegarde. Nous récupérons le script et nous l'exécuterons sur chaque serveur. 
La ligne à changer : 

    rsync -rlptD --stats /backup/confapache/apache.conf $utilisateurrsync@$192.168.30.252::sauvegarde

La restauration des données est donc terminé. 

Concernant l'hyperviseur Hyper-V, nous exportons régulièrement nos machines virtuelles sur notre disque dur. 

Pour effectuer une exportation, nous faisons un clic droit sur chaque VM et nous choisissons "Exporter" ensuite nous choisissons le chemin de notre disque dur externe puis nous faisons "Exporter". 

En plus de l'outil rsync nous avons installer un outil : VeamBackup pour faire une sauvegarde de l'hyperviseur complet.  Il fait des sauvegardes des VM sur un disque dur du serveur physique. 

## Scénario Web :

Le Scénario Web consiste en une ou plusieurs requêtes HTTP ou "étapes". Les étapes sont exécutées périodiquement par le serveur Zabbix dans un ordre prédéfini. Si un hôte est supervisé par proxy, les étapes sont exécutées par le proxy.

Pour configurer un scenario web :

-   Allez dans :  _Configuration → Hôtes_  (ou  _Modèles_)
-   Cliquez sur  _Web_  dans la ligne de l'hôte/modèle
-   Cliquez sur  _Créer un scénario web_  à droite (ou sur le nom du scénario pour modifier un scénario existant)
-   Entrez les paramètres du scénario dans le formulaire

L'onglet  **Scénario**  vous permet de configurer les paramètres généraux d'un scénario Web.

L'onglet  **Étapes**  vous permet de configurer les étapes du scénario web. Pour ajouter une étape d'un scénario web, cliquez sur  _Ajouter_  dans le bloc  _Étapes_.
