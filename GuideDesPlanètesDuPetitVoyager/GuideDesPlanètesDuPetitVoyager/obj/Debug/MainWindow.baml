   M S B A M L   `   `   `  ����Z  VGuideDesPlanètesDuPetitVoyager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:GuideDesPlanètesDuPetitVoyagerGuideDesPlanètesDuPetitVoyager  5   	   g8clr-namespace:GuideDesPlanètesDuPetitVoyager.ViewModels*GuideDesPlanètesDuPetitVoyager.ViewModels  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�`clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions'Microsoft.Expression.Interactivity.Core 5	   	   0    *GuideDesPlanètesDuPetitVoyager.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:GuideDesPlanètesDuPetitVoyager     5   	   Gvm8clr-namespace:GuideDesPlanètesDuPetitVoyager.ViewModels     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   pexp`clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions     5	   	   -   5        $%��LeGuideDesPlaneteDuPetitVoyager��5   	     � Title$-  'Le guide des planètes du petit Voyager��5   	   $	��350��68   $	��530��6E   
���   � � Icon$ Images\icon.png��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��0.75* �6   �� 5      $��7* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��4* �6   .+�5   
   �� $��Images\fondliste.jpg��6   $��1��6.   $��3��6;   $��2��6L   $
��Left=�6`   �� 5   
   $��1��6   $��1��6   $��2��6-   $��3��6A   $��Images\fond.jpg��6R   $
��Left=�6k   �� 5   
   $��Images\Baniere2.jpg��6   $��2��6-   �� 5   
   -   5        $��
NomPlanete��5      $��1��6$   $��1��64    �� TextAlignment$ Center=�6�    �� 
IsReadOnly . 
����d�$��0q�6�   $��Center=�6�   $
��Bold"�6�   ��6A   �� *Planete.Nom+ �� UpdateSourceTrigger$ PropertyChanged=�.��6  ��5       �� 5!       �� Color$ White��6"    �� Opacity$ 0Q�60   .��5"   "   5#      � 5$   
   $��1��6   $��2��6    5&      �� 5'      $
��0.7* �6    �� 5(      $
��0.7* �6    �� 5)      $��4* �6    .+�5,      �� $��0��6   	 �� Orientation$	 
Horizontal=�6&   $��0,2,0,2q�6?   $��Center=�6P   .+�5-      �� 
 �� CornerRadius$
 10��6   
�������
���   �$��2q�6Q    �� Padding$ 3q�6e   $��5,0,5,0q�6q   ._�5.      �� $	 
Horizontal=�6!   .+�5/      �� $��Volume :��6"    . 
���   ����	#FF1CC7B7$��0q�6n   $��Center=�6�   �� 50       . 
���   �$ Right=�6�   
����d�$��0q�6�   $��Center=�6�   $��60��6�   ��6"   �� *Planete.Volume+$ PropertyChanged=�6�   �� 51      $	��Km3��6"    . 
���   ����	#FF1CC7B7$��0q�6i   $��Center=�6}   52      53      �� 54      $
 10��6   
�������
���   �$��2q�6Q   $ 3q�6e   ._�55      �� $	 
Horizontal=�6!   .+�56      �� $��Masse :��6"    . 
���   ����	#FF1CC7B7$��0q�6m   $��Center=�6�   �� 57       . 
���   �$ Right=�6�   
����d�$��0q�6�   $��Center=�6�   $��60��6�   ��6"   �� *Planete.Masse+$ PropertyChanged=�6�   �� 58      $��Tonnes��6"    . 
���   ����	#FF1CC7B7$��0q�6l   $��Center=�6�   $��40��6�   59      5:      �� 5;      $
 10��6   
�������
���   �$��2q�6Q   $ 3q�6e   $��5,0,5,0q�6q   ._�5<      �� $	 
Horizontal=�6!   .+�5=      �� $��	Anneaux :��6"    . 
���   ����	#FF1CC7B7$��0q�6o   $��Center=�6�   �� 5>       . 
���   �
����d�$��0q�6�   $��Center=�6�   $��30��6�   ��6"   �� *Planete.Anneaux+$ PropertyChanged=�6�   5?      5@      5A      �� 5C      $��1��6   $	 
Horizontal=�6&   $��0,2,0,2q�6?   $��Center=�6P   .+�5D      �� $
 10��6   
�������
���   �$��2q�6Q   $ 3q�6e   $��5,0,5,0q�6q   ._�5E      �� $	 
Horizontal=�6!   .+�5F      �� $��Découverte :��6"    . 
���   ����	#FF1CC7B7$��0q�6r   $��Center=�6�   �� 5G       . 
���   �
����d�$��0q�6�   $��Center=�6�   $��65��6�   $ Right=�6�   ��6"   �� *Planete.AnnéeDecouverte+$ PropertyChanged=�6�   5H      5I      �� 5J      $
 10��6   
�������
���   �$��2q�6Q   $ 3q�6e   ._�5K      �� $	 
Horizontal=�6!   .+�5L      �� $��Satellites :��6"    . 
���   ����	#FF1CC7B7$��0q�6r   $��Center=�6�   �� 5M       . 
���   �
����d�$��0q�6�   $��Center=�6�   $��25��6�   ��6"   �� *Planete.NbreSatellite+$ PropertyChanged=�6�   5N      5O      �� 5P      $
 10��6   
�������
���   �$��2q�6Q   $ 3q�6e   $��5,0,5,0q�6q   ._�5Q      �� $	 
Horizontal=�6!   .+�5R      �� $��Révolution:��6"    . 
���   ����	#FF1CC7B7$��0q�6q   $��Center=�6�   �� 5S       . 
���   �$ Right=�6�   
����d�$��0q�6�   $��Center=�6�   $��45��6�   ��6"   �� *Planete.PeriodeRevo+$ PropertyChanged=�6�   �� 5T      $��jours��6"    . 
���   ����	#FF1CC7B7$��0q�6k   $��Center=�6   5U      5V      5W      � 5Y      $��2��6    5Z      �� 5[      $��9* �6$   �� 5\      $
��Auto �6$   �� 5]      $
��Auto �6$   .+�5_      �� $
 10��6   
�������$��2q�6>   $ 3q�6R   $��0,2,0,2q�6^   ��5`      �� 5a      $ Black��6*   $ 0Q�68   ._�5c      � $��0��6    5d      �� 5e      �� 5f      $��2* �6/   �� 5g      .+�5j      �� $��1��6s   ��6    �� *Planete.PlanIm+ �� Mode$ TwoWay=�$ PropertyChanged=�6s   5k      5l      5m      5n      � 5p   
   $��1��6    5q      �� 5r      $
��2.5* �6#   �� 5s      $��1* �6#   .+�5v      �� -   5        $
��text��5v      $��0��6h   $��Italic$�6x   ���	#99000000
�������$��14(�6�   ��6"   �� *.TextRecherche+$ PropertyChanged=�.��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5w      /  )System.Windows.Interactivity.EventTrigger  5x         	EventName$ GotFocus��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5y      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ GotFocusAction��6/      TargetObject 6K   �� 6f   5z      .��5{   *   5|      �� 5}      $��1��6   ��6%   �� *ClickOnSearch+.��5~      �� $��Images/iconRech.png��6   5      5�      � 5�   
   $��2��6   $��2��6    5�      �� 5�      $
��7.5* �6    �� 5�       5�      �� 5�      �� 5�      .+�5�      �� -   5        $��ListP��5�      ���	#7F000000$��0q�6�   $��0��6�   $��2��6�   
�������$
��Bold"�6�   $��
0,0,0,10.4q�6�   $��2��6  ��6'   �� *	Univers+$ PropertyChanged=� �� SelectedItem 6l   �� *	Planete+6  �� 5�      $	��8.5(�6   $��2��6)   ��66   �� *OnImportCommande+.��5�      �� $��Importer des planètes��6    $
��Wrap=�6=    �� TextAlignment$ Center=�6Q   5�      �� 5�      $	��8.5(�6   $��2��6%   $��1��63   ��6D   �� *OnExportCommande+.��5�      �� $��Exporter  des planètes��6   $
��Wrap=�66   $ Center=�6J   5�      5�      � 5�   
   $��1��6   $��3��6    5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $��Ajouter��6   $	��Top=�6'   $��Center=�6?   $��0��6\   $	��2.5q�6l   ��6z   �� *OnAddCommande+�� 5�      $��Modifier��6   $��Bottom=�6(   $��Center=�6C   $��1��6`   $	��2.5q�6p   ��6~   �� *OnEditCommande+�� 5�      $��	Supprimer��6   $	��Top=�6)   $��Center=�6A   $��2��6^   $	��2.5q�6n   ��6|   �� *OnDeleteCommande+5�      5�      5�      