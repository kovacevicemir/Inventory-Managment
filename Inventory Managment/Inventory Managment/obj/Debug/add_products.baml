   M S B A M L   `   `   `  ����N  JInventory Managment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Inventory_ManagmentInventory_Managment  5   	   &     Inventory_Managment.add_products   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Inventory_Managment     5   	     � Title$  Add new products��5   	   $	��800��5	   	   $
��1024��5
   	   $��13(�6   .��5      � ��5   
   �� 5       �� Color# � ��6   .+�5   
   �� 
���   �$��2,1,1,1q�6%   $
��Left=�6?   $��82��6Z   $��
49,119,0,0q�6f   $	��Top=�6z   $	��903��6�    J� Opacity$	 0.1Q�6�   
���   �6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��208��6T   $��
49,241,0,0q�6a   $	��Top=�6u   $	��330��6�   $	 0.1Q�6�   
���   �6�   �� 5   
   -   5         ��Name$ comboBox_units��5      $
��Left=�6+   $��590,148,0,0q�6F   $	��Top=�6[   $	��200��6s   �� 5   
   -   5         ��Name$ input_product_name��5      $
��Left=�6.   $��23��6I   $��210,149,0,0q�6U    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��200��6�   �� 5   
   -   5         ��Name$ label��5      $��Add New Products��6   $
��Left=�6:   $��
391,46,0,0q�6U   $	��Top=�6i   $
��Bold"�6�   $��26(�6�   �� 5   
   -   5        $ 
label_Copy��5      $��Product Name��6$   $
��Left=�6;   $��
91,148,0,0q�6V   $	��Top=�6j   $
��Bold"�6�   $��13(�6�   �� 5   
   -   5        $ label_Copy1��5      $��Product Unit��6%   $
��Left=�6<   $��479,148,0,0q�6W   $	��Top=�6l   $
��Bold"�6�   $��13(�6�   �� 5   
   -   5         ��Name$ btn_add_product��5      $��Insert��6*   $
��Left=�6;   $��825,148,0,0q�6V   $	��Top=�6k   $��92��6�   $��28��6�    �� 	IsDefault . 6�   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 dataGrid_products��5      $
��Left=�6^   $��414,241,0,0q�6y   $	��Top=�6�   $	��420��6�   
   MinColumnWidth$	
 100Q�6�   $	��538��6�   �� 5   
   -   5        $ label_Copy2��5      $��Product Name��6%   $
��Left=�6<   $��
91,285,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   $��13(�6�   �� 5   
   -	   5        $ label_Copy3��5      $��Select Unit��6%   $
��Left=�6;   $��
91,343,0,0q�6V   $	��Top=�6j   $
��Bold"�6�   $��13(�6�   �� 5   
   -
   5        $ input_product_name_upd��5      $
��Left=�62   $��23��6M   $��210,289,0,0q�6Y   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ comboBox_units_2��5      $
��Left=�6-   $��210,346,0,0q�6H   $	��Top=�6]   $	��120��6u   �� 5   
   -   5        $ btn_update_product��5      $��Update��6-   $
��Left=�6>   $��238,392,0,0q�6Y   $	��Top=�6n   $��92��6�   $��28��6�    . 6�   �� 5   
   -   5        $ btn_delete_product��5      $��Delete��6-   $
��Left=�6>   $��867,678,0,0q�6Y   $	��Top=�6n   $��85��6�   $��24��6�   6�   �� 5   
   -   5        $ label1��5      $,��&To delete select product from the list��6    $
��Left=�6Q   $��696,678,0,0q�6l   $	��Top=�6�   $��Italic$�6�   $��10(�6�   5       5!      