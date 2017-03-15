![](https://lh3.googleusercontent.com/xF2sAJF0UIOxVW618rZqWEmYDRx6lB_NpezX0W1t9z97CQVA94InQO7LEOPPMzaQEj4vc2OAxvXa0N0=w3140-h1642-rw)

# Hackathon Kit-Démarrage
Ceci est une trousse de démarrage pour le hackathon de Radio-Canada.

### Prerequis
- Compte Azure (https://azure.microsoft.com/en-us/free/)
- App ID pour les réseau sociaux
- Accès fonctionnel pour les API de Radio-Canada

#### Si vous désirez faire du réseau sociaux
###### Pour obtenir un Facebook APP ID (https://developers.facebook.com/apps)
- Pour les étapes vous pouvez consulter les saisies d'écran via /screenshots/Facebook_AppID/
[![IMAGE ALT TEXT HERE](http://img.youtube.com/vi/8i9p3D854O4/0.jpg)](http://www.youtube.com/watch?v|8i9p3D854O4)

###### Pour obtenir un Twitter APP ID (https://apps.twitter.com/)
- Pour les étapes vous pouvez consulter les saisies d'écran via /screenshots/Twitter_AppID/
[![IMAGE ALT TEXT HERE](http://img.youtube.com/vi/9ckccMDhtQI/0.jpg)](http://www.youtube.com/watch?v|9ckccMDhtQI)

###### Pour obtenir un Instagram APP ID (https://www.instagram.com/developer/)
- Pour les étapes vous pouvez consulter les saisies d'écran via /screenshots/Instagram_AppID/
[![IMAGE ALT TEXT HERE](http://img.youtube.com/vi/EZ6_1mm11kg/0.jpg)](http://www.youtube.com/watch?v|EZ6_1mm11kg)

### API Radio-Canada
- Neuro (http://services.radio-canada.ca/hackathon2017/neuro/v1/documentation)
- MediaNet 
- Picto
- SiteSearch (https://services.radio-canada.ca/hackathon2017/sitesearch/help)

### Exemple consommation Neuro
> http://services.radio-canada.ca/neuro/v1/future/lineups/{lineupId}

#### Exemple de line up

Line up ID | Nom
--- | --- 
131270 | Ppage - Une - Région - Grand Montréal
117812 | Économie
117814 | Famille
117815 | Histoire
117816 | Humour
117820 | Politique
92411 | Justice - À la une
4165 | Science - À la une
4167 | Arts - À la une
4169 | Techno - À la une

#### Exemple consommation MediaNet
> Par exemple pour une nouvelles : 
> http://services.radio-canada.ca/hackathon2017/neuro/v1/news-stories/1005274
> Vous allez retrouver sous summaryMultimediaContent un selflink qui est 
> http://services.radio-canada.ca/hackathon2017/neuro/v1/media/7647781
> Pour connecter le player medianet
> 

#### Exemple consommation Picto
> http://images.radio-canada.ca/v1/ici-info/1x1/lucie-charlebois-ministre.png

#### Exemple consommation sitesearch
> Faites un appel vers https://services.radio-canada.ca/hackathon2017/sitesearch/v1/internal/rcgraph/indexable-content-summaries
> Utilisez le api key comme ci-dessous dans l'entête de la requête
 
Nom d'entête | Valeur
--- | --- 
Authorization | Client-Key 31e51cda-4ab0-4234-83c2-25d503c69487

#### Exemple de content type id pour sitesearch
Type de contenu | ID
--- | --- 
Unknown | 0
Media | 1
YouTube | 3
SoundCloud | 4
Vine | 5
Instagram | 6
Vimeo | 7
RadioHeadlineItem | 8
ShortContent | 9
MuContent | 10
NewsStory | 11
RadioWebCast | 12
LiveWebCast | 13
AdHoc | 14
MediaThreadCue | 15
RadioProgrammeCard | 16
TvProgrammeCard | 17
Episode | 18
Picto | 19
Ght1tImage | 20
NotIndexedImage | 21 
MusicTrack | 22
BroadcastableContentComplement | 23
Programme | 24
Season | 25
Clip | 26
NotIndexedContent | 27
Lineup | 28
Dossier | 29
PhotoAlbumV1 | 30
PhotoAlbumV2 | 31
SportCalendar | 32
MusicTrackDiskAdmin | 33
Sotchi2014Content | 34
Subject | 35
GregContent | 36
MusicHallWebPage | 37
WebRadio | 38
ZBlogPost | 40
BlogPost | 41
CueSheet | 42
Cue | 43
PodcastChannel | 44
ClipType | 45
BroadcastableContentComplementType | 46
Panam2015Content | 47
LiveWebCastChannel | 48
HtmlSnippet | 49
PressAgency | 50
BroadcastingNetwork | 51
Alert | 52
FirstPlay | 53
MusicAlbum | 54
Region | 55

### Contact
Pour plus d'information vous pouvez contacter :
- Viet Nguyen (mailto: quoc-viet.nguyen@radio-canada.ca)
- Hugo Leclerc (mailto: hugo.leclerc@radio-canada.ca)
- Dominic Fortin (mailto: hackathon@radio-canada.ca)
