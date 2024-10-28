﻿using System.ComponentModel;
using System.Windows;

namespace NBackTask;

public partial class SetupEditor : Window, INotifyPropertyChanged
{
    public IEnumerable<string> SetupNames { get; }
    public SetupData SetupData => _setups[_selectedSetupIndex];

    public event PropertyChangedEventHandler? PropertyChanged;

    public int SelectedSetupIndex
    {
        get => _selectedSetupIndex;
        set
        {
            _selectedSetupIndex = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SetupData)));
        }
    }

    internal SetupEditor(SetupData[] setups)
    {
        InitializeComponent();

        _setups = setups;
        SetupNames = setups.Select(setup => setup.Name);

        DataContext = this;
    }

    // Internal

    readonly SetupData[] _setups;

    int _selectedSetupIndex = 0;

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}
