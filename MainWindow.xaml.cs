﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

namespace Kniga_Recepts
{
    public partial class MainWindow : Window
    {
        static string dirRecipes = "Recipes";
        List<string> listRecipes = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            GetFileReceipt();
            LoadListBox();
        }
        private void LoadXML(string name)
        {
            using (XmlReader reader = XmlReader.Create($@"{dirRecipes}\{name}.xml"))
            {
                FlowDocument flowDocument = (FlowDocument)XamlReader.Load(reader);
                scrollDoc.Document = flowDocument;
            }
        }
        private void LoadListBox()
        {
            for (int i = 0; i < listRecipes.Count; i++)
            {
                listBox.Items.Add(listRecipes[i]);
            }
        }

        private void GetFileReceipt()
        {
            foreach (string file in Directory.GetFiles(dirRecipes))
            {
                if (System.IO.Path.GetExtension(file) == ".xml")
                {
                    listRecipes.Add(System.IO.Path.GetFileNameWithoutExtension(file));
                }
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ListBox? list = sender as ListBox;
                if (list != null)
                {
                    LoadXML(list.SelectedItem.ToString());
                }
            }
            catch (Exception) { }
        }
    }
}
