   M S B A M L   `   `   `  ����H  DPersonTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonTrackerPersonTracker  5   	       PersonTracker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PersonTracker     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)   .��5	      � $��-12,-14,12.2,14.8q�6   .+�5
   
   �� -   5         ��Name$ 	btnSubmit��5
      $��Show Gender DataGrid��6$   $
��Left=�6C   $��
52,438,0,0q�6^   $	��Top=�6r   $	��158��6�   $��42��6�    J� RenderTransformOrigin$ 1.122,0.811&�6�   �� 5   
   -   5         ��Name$ 
lblMessage��5      $��Label��6$   $
��Left=�64   $��
52,310,0,0q�6O   $	��Top=�6c   $��55��6{   $	��326��6�   �� 5   
   -   5        $ btnClose��5      $��Close Program��6#   $
��Left=�6;   $��
52,374,0,0q�6V   $	��Top=�6j   $	��158��6�   $��42��6�   $ 1.122,0.811&�6�   6�   �� 5   
   -   5         ��Name$ 
personList��5      $	��238��5      $
��Left=�5      $��	48,60,0,0q�5      $	��Top=�5      $	��461��5      $ 0.5,0.5&�6   z�5      V� 5      .~�5      �� �� 5       �� AngleY$ -0.304Q�6$   �� 5      T� 5       T� Y$ -0.795Q�6)   5       �� View 5      �� 5      .P�5      ��  �� Width$ 50��6%   $��Id��60   	 �� DisplayMemberBinding	 6=   �� 
 �� Path$
 Id�6i   �� 5       $	 200��6%   $
��Name��61   	 6?   �� $

 Name�6l   �� 5!      $	 100��6%   $��Gender��61   	 6A   �� $
 Gender�6p   5"      5$      �� 5%   
   -   5        $ btnDeletePerson��5%      $��Delete Selected Person��6*   $
��Left=�6K   $��559,131,0,0q�6f   $	��Top=�6{   $	��159��6�   $��42��6�   $ 0.257,0.357&�6�   �� 5'   
   -   5        $ 	lblDelete��5'      $
��Left=�6a   $��
52,339,0,0q�6|   $	��Top=�6�   $	��362��6�   ��6$   �� *SelectedValue.Id+ �� ElementName$ 
personList��6�   �� 5(   
   -   5        $ btnUpdatePerson��5(      $��Update Selected Person��6*   $
��Left=�6K   $��559,199,0,0q�6f   $	��Top=�6{   $	��159��6�   $��42��6�   6�   �� 5)   
   -   5        $ 	btnCreate��5)      $��Create New Person��6$   $
��Left=�6@   $��
559,63,0,0q�6[   $	��Top=�6o   $	��159��6�   $��42��6�   $ 
4.16,2.411&�6�   6�   �� 5*   
   -	   5        $ 
btnRefresh��5*      $��Refresh��6%   $
��Left=�67   $��335,374,0,0q�6R   $	��Top=�6g   $	��159��6   $��39��6�   6�   5+      5,      