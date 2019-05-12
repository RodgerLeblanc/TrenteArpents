using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace TrenteArpents.ViewModels
{
    public class MotDeMDoyonViewModel : BaseViewModel
    {
        public MotDeMDoyonViewModel()
        {
            Title = "Mot de M. Doyon";
        }

        public double TextTitleFontSize { get => 24; }
        public double FormattedTextFontSize { get => 16; }

        public string TextTitle { get => "POURQUOI LES AGENTS IMMOBILIERS IDENTIFIENT-ILS LE DOMAINE DES TRENTE ARPENTS COMME UN MILIEU DE VIE DISTINCTIF ET RECHERCHÉ?"; }

        public FormattedString FormattedText
        {
            get
            {
                FormattedString formattedText = new FormattedString();

                formattedText.Spans.Add(new Span { Text = "Souvent, quand il y a une propriété à vendre au Domaine, l’on peut lire dans l’annonce publié par le vendeur une petite note qui fait référence à ce milieu de vie;", FontSize = FormattedTextFontSize });
                formattedText.Spans.Add(new Span { Text = " au Domaine des 30 Arpents,", FontAttributes = FontAttributes.Bold | FontAttributes.Italic, FontSize = FormattedTextFontSize });
                formattedText.Spans.Add(new Span { Text = " superbe quartier familial, sécuritaire et paisible, secteur d’exception, etc.", FontAttributes = FontAttributes.Italic, FontSize = FormattedTextFontSize });
                formattedText.Spans.Add(new Span { Text = @"
Ce n’est pas d’hier que je remarque cette précision et à toutes les fois, ça attire mon attention puisqu’il est très rare de voir identifié avec autant d’emphase le secteur de développement de la propriété à vendre. Il y a donc là quelque chose de bien particulier qui fait la différence, qui est accrocheur et qui supporte le prix demandé pour la propriété.

Bien entendu, comme promoteur, c’est flatteur de voir le Domaine ainsi identifié et je comprends que cette distinction peut venir de l’aménagement sécuritaire des rues à circulation restreinte, de la belle harmonie des architectures, de la protection d’un milieu de vie richement boisé, de la présence de beaux parcs, de la grande proximité d’une forêt sillonnée de plusieurs sentiers accueillants, d’écoles primaires, de complexes récréatifs et culturels, de plusieurs parcs et terrains sportifs, d’un CPE et de nombreux commerces.

Mais je pense réellement que ce qui donne toute sa distinction au Domaine, ce sont vous les résidents. En plus de vos belles propriétés bien paysagées et admirablement entretenues, il y a une dynamique toute particulière. À ce niveau, je n’ai que des félicitations à formuler, année après année, à l’attention des membres actifs de ce comité qui organise cette belle fête de quartier et qui coordonne aussi un ensemble d’activités au Domaine tout au long de l’année.

Oui, le Domaine des Trente Arpents, c’est un milieu de vie familial distinctif et l’expansion se poursuit; on planifie le développement des derniers terrains du secteur Est et l’on travaille de beaux projets pour le secteur Ouest, où encore près de 400 terrains pourront être rendus disponibles au cours des prochaines années.

Toujours un plaisir de vous retrouver à cette belle Fête de Quartier!

Jean Doyon, Promoteur", FontSize = FormattedTextFontSize });

                return formattedText;
            }
        }
    }
}