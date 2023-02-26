import unidecode

f = open("StopWordsFr.txt", 'r', encoding='UTF-8')
tab_words = f.readlines()
output = open("stop_words_french_accentless.txt", 'w', encoding = 'UTF-8')
n_tab = []
#On va parcourir notre tableau pour remove les accents
for mot in tab_words : 
    mot = unidecode.unidecode(mot) 
    if ((mot not in n_tab) and len(mot)>2)  : 
        n_tab.append(mot)

output.writelines(n_tab)