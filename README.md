# Sécurisation des Licences ERP

## Objectif

L'objectif de ce projet est de développer une solution pour protéger les licences du logiciel AtooERP contre le piratage. Le projet inclut la création de clés d'activation et la vérification à distance des licences, avec l'utilisation de C# et SQL Server.

## Table des matières

- [Introduction](#introduction)
- [Architecture du projet](#architecture-du-projet)
  - [Côté Serveur](#côté-serveur)
  - [Côté Client](#côté-client)


## Introduction

La solution est composée de deux parties principales : le côté serveur et le côté client.

## Architecture du projet

### Côté Serveur

Le serveur a pour rôle de créer une clé d’activation

### Côté Client

#### Introduction

Le client est composé de trois parties :


1. **Partie d’inscription :** Collecte des informations du client via un formulaire.

![atoo1](https://github.com/user-attachments/assets/f3401a3d-7749-453f-8133-3d1231224216)


2. **Partie d’activation :** Affiche la clé d’activation générée par le serveur.

![atoo2](https://github.com/user-attachments/assets/d4eade08-c64f-4223-ae8d-a0e7381c330e)


3. **Partie d’utilisation :** Solution obtenue après l’activation du produit.

![atoo3](https://github.com/user-attachments/assets/2fbbc921-4135-4eca-8d08-aacf55c7621c)


4. **Partie expiration :** Solution obtenue après l’activation du produit.

![atoo4](https://github.com/user-attachments/assets/10488fee-5658-483b-af7c-78ae7a38c329)

   
