   M S B A M L   `   `   `  ����N  JInventory Managment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Inventory_ManagmentInventory_Managment  5   	   &     Inventory_Managment.Add_new_user   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Inventory_Managment     5   	     � Title$  Add new user��5   	   $	��800��5	   	   $
��1300��5
   	   .��5      � ��5   
   �� 5       �� Color# � ��6   .+�5   
   �� -   5         ��Name$ label��5      $��	FirstName��6   $
��Left=�63   $��186,164,0,0q�6N   $	��Top=�6c    J� RenderTransformOrigin$ -10.031,-2.422&�6{   $��16(�6�   $
��Bold"�6�   $	��117��6�   �� 5   
   -   5        $ 
label_Copy��5      $��LastName��6$   $
��Left=�67   $��186,247,0,0q�6R   $	��Top=�6g   $ -10.031,-2.422&�6   $��16(�6�   $
��Bold"�6�   $	��111��6�   �� 5   
   -   5        $ label_Copy1��5      $��UserName��6%   $
��Left=�68   $��186,321,0,0q�6S   $	��Top=�6h   $ -10.031,-2.422&�6�   $��16(�6�   $
��Bold"�6�   $	��117��6�   �� 5   
   -   5        $ label_Copy2��5      $��Password��6%   $
��Left=�68   $��186,398,0,0q�6S   $	��Top=�6h   $ -10.031,-2.422&�6�   $��16(�6�   $
��Bold"�6�   $	��104��6�   �� 5   
   -   5        $ label_Copy3��5      $��Email��6%   $
��Left=�65   $��186,471,0,0q�6P   $	��Top=�6e   $ -10.031,-2.422&�6}   $��16(�6�   $
��Bold"�6�   $��67��6�   �� 5   
   -   5        $ label_Copy4��5      $��Contact��6%   $
��Left=�67   $��186,548,0,0q�6R   $	��Top=�6g   $ -10.031,-2.422&�6   $��16(�6�   $
��Bold"�6�   $��91��6�   �� 5   
   -   5         ��Name$ add_user_first_name��5      $��23��6/   $	��200��6>   $
��Left=�6M   $��23��6h   $��316,170,0,0q�6t    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��298��6�   $
��Bold"�6�   �� 5   
   -   5        $ add_user_last_name��5      $��23��6.   $	��200��6=   $
��Left=�6L   $��23��6g   $��316,256,0,0q�6s   $
 Wrap=�6�   $	��Top=�6�   $	��298��6�   $
��Bold"�6�   �� 5   
   -	   5        $ add_user_username��5      $��23��6-   $	��200��6<   $
��Left=�6K   $��23��6f   $��316,327,0,0q�6r   $
 Wrap=�6�   $	��Top=�6�   $	��298��6�   $
��Bold"�6�   �� 5   
   -
   5        $ add_user_password��5      $��23��6-   $	��200��6<   $
��Left=�6K   $��23��6f   $��316,404,0,0q�6r   $
 Wrap=�6�   $	��Top=�6�   $	��298��6�   $
��Bold"�6�   �� 5   
   -   5        $ add_user_email��5      $��23��6*   $	��200��69   $
��Left=�6H   $��23��6c   $��316,477,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��298��6�   $
��Bold"�6�   �� 5   
   -   5        $ add_user_contact��5      $��23��6,   $	��200��6;   $
��Left=�6J   $��23��6e   $��316,554,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��298��6�   $
��Bold"�6�   �� 5   
   -   5        $ label1��5      $��Add New User��6    $
��Left=�67   $��
336,54,0,0q�6R   $	��Top=�6f   $ -0.594,0.422&�6~   $��30(�6�   $
��Bold"�6�   $	��278��6�   �� 5   
   -   5         ��Name$ btn_add_user��5      $��Add New User��6'   $
��Left=�6>   $��394,618,0,0q�6Y   $	��Top=�6n   $	��123��6�   $ -1.253,-0.02&�6�   $��16(�6�   $
��Bold"�6�   $��39��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid_users��5         AutoGenerateColumns . 	   SelectionMode$	 Single=�6F   
   SelectionUnit$
 FullRow=�6]   $
��Left=�6u   $��666,170,0,0q�6�   $	��Top=�6�   $	��410��6�   $	��606��6�   �� 5    
   -   5        $ btn_delete_user��5       $��Delete Selected User��6*   $
��Left=�6I   $��891,618,0,0q�6d   $	��Top=�6y   $	��152��6�   $��39��6�   $
��Bold"�6�   6�   5!      5"      