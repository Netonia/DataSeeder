# PRD - DataSeeder Blazor WebAssembly

## Objectif
DataSeeder est une application Blazor WebAssembly qui permet aux développeurs et testeurs de générer rapidement des jeux de données réalistes pour leurs environnements de développement ou bases locales. L'application utilise des modèles configurables et des templates Liquid pour personnaliser la sortie des données.

## Public cible
- Développeurs .NET / Blazor
- Testeurs QA
- Data engineers
- Toute personne ayant besoin de jeux de données fictifs pour tests ou démonstrations

## Fonctionnalités principales

### 1. Gestion de modèles de données
- Ajouter, modifier, supprimer des modèles d'entités (ex : Utilisateur, Produit, Commande).
- Chaque modèle contient une liste de champs avec :
  - Nom
  - Type de données (string, int, decimal, bool, date, email, prénom, nom, ville, pays, UUID, etc.)
  - Contraintes (longueur, format, plage de valeurs)
- Interface CRUD simple pour gérer les modèles.

### 2. Génération aléatoire de données
- Utilisation de **Bogus** pour générer des données réalistes (noms, adresses, emails, villes).
- Types simples générés via **System.Random** (int, decimal, bool).
- Paramètres de génération : nombre de lignes, batch size.

### 3. Templates Liquid (Fluid.Core)
- Permet de définir un template pour personnaliser la sortie.
- Support des boucles `{% for item in items %}` et conditions `{% if %}`.
- Exemple de template :
  ```liquid
  {{ firstName }} {{ lastName }} - {{ email }}
  ```
- Rendu dynamique en temps réel.

### 4. Prévisualisation et filtrage
- Aperçu instantané des données générées selon le template.
- Possibilité de trier et filtrer les résultats.
- Mise en évidence des erreurs de génération ou de template.

### 5. Export et injection
- Export des données générées en **CSV, JSON ou SQL**.
- Copier dans le presse-papier.
- Option future : injection directe dans SQLite WASM ou autres bases locales.

### 6. Stockage local des modèles et templates
- Sauvegarde des modèles et templates dans **IndexedDB ou localStorage**.
- Gestion de multiples modèles par projet.
- Rappel automatique du dernier modèle utilisé.

## Architecture technique
- **Blazor WebAssembly** : front-end 100% client.
- **Bogus** : génération de données réalistes.
- **Fluid.Core** : parsing et rendu des templates Liquid.
- **Monaco Editor** : édition avancée des templates Liquid.
- **RandomDataService** : service C# pour génération des champs.
- **TemplateService** : service C# pour rendu Liquid.
- **StorageService** : persistance locale des modèles et templates.

## UI/UX
- **Panneau gauche** : liste des modèles et gestion des champs.
- **Panneau droit** : éditeur Liquid + prévisualisation des données.
- **Barre supérieure** : configuration globale (nombre de lignes, options de génération).
- Boutons principaux : `Ajouter modèle`, `Générer`, `Copier`, `Exporter`.
- Indicateur de chargement pour génération volumineuse.

## Contraintes
- 100% client-side, pas de serveur requis.
- Compatible avec navigateurs modernes.
- Limite configurable du nombre de lignes pour éviter freeze.

## Extensions possibles
- Relations entre modèles (ex : Commande → Utilisateur, Produit).
- Génération conditionnelle (ex : date livraison > date commande).
- Export HTML/PDF via template Liquid.
- Partage de modèles/templates via JSON ou URL.
- Multi-template preview pour comparer différentes mises en forme.

## Exemple de workflow utilisateur
1. L'utilisateur crée un modèle `Utilisateur` avec champs : `firstName`, `lastName`, `email`, `city`.
2. L'utilisateur définit un template Liquid : `{{ firstName }} {{ lastName }} - {{ email }} - {{ city }}`.
3. L'utilisateur génère 100 lignes de données.
4. Les résultats sont affichés dans la prévisualisation.
5. L'utilisateur exporte les données en CSV et les copie dans le presse-papier pour utilisation dans une base de développement.

---

Fin du PRD

