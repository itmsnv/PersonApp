   M S B A M L   `   `   `  ����H  DPersonTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonTrackerPersonTracker  5   	        PersonTracker.CreatePerson   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PersonTracker     5   	     � Title$  CreatePerson��5   	   $	��300��6   $	��300��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��104* �6   �� 5      $	��31* �6   .+�5   
   �� $��First Name:��6   $
��Left=�6&   $��
52,100,0,0q�6A   $	��Top=�6U   $��98��6m   �� 5   
   -   5         ��Name$ txtFirstName��5      $
��Left=�6(   $��23��6C   $��131,103,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��120��6�   �� 5   
   -   5         ��Name$ 	cmbGender��5       �� DisplayMemberPath$
 Name��6&    �� SelectedValuePath$ Id��6A   $
��Left=�6Z   $��
131,53,0,0q�6u   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ btnCreatePerson��5      $��Create Person��6*   $
��Left=�6B   $��102,154,0,0q�6]   $	��Top=�6r   $	��149��6�   $��42��6�   6�   �� 5   
   $��Select Gender:��6   $
��Left=�6)   $��	42,53,0,0q�6D   $	��Top=�6W   $��98��6o   �� 5   
   -   5         ��Name$ 
lblMessage��5      $��Label��6$   $
��Left=�64   $��	60,10,0,0q�6O   $	��Top=�6b   $��29��6z   $	��179��6�   $��1��6�   5      5      