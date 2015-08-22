﻿Imports System.Windows.Forms

Imports MahApps.Metro
Imports MahApps.Metro.Native
Imports MahApps.Metro.Controls

Partial Class MetroConfig
    Inherits MetroWindow

    Sub Load() Handles Me.Loaded
        comboStatusPosition.Items.Add("Top Left")
        comboStatusPosition.Items.Add("Bottom Left")
        comboStatusPosition.Items.Add("Top Right")
        comboStatusPosition.Items.Add("Bottom Right")

        slideSpeed.Minimum = 0
        slideSpeed.Maximum = 2

        slideThreshold.Minimum = 20
        slideThreshold.Maximum = 100

        checkListenAtStartup.IsChecked = My.Settings.autoListen
        checkShowStatusText.IsChecked = My.Settings.showStatusText
        comboStatusPosition.IsEnabled = My.Settings.showStatusText
        comboStatusPosition.SelectedIndex = My.Settings.statusTextPos
        checkShowLast.IsEnabled = My.Settings.showStatusText
        checkShowLast.IsChecked = My.Settings.showLast
        checkSmoothMouse.IsChecked = My.Settings.smoothCursor
        slideSpeed.Value = My.Settings.cursorSpeed

        slideThreshold.Value = My.Settings.Threshold
        checkQuickPlay.IsChecked = My.Settings.quickPlay
        checkPlayAudio.IsChecked = My.Settings.playAudio

        Select Case My.Settings.toggleOrPTT
            Case True
                radioPTT.IsChecked = True

            Case False
                radioToggle.IsChecked = True
        End Select

    End Sub

    Private Sub Button_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        My.Settings.autoListen = checkListenAtStartup.IsChecked
        My.Settings.showStatusText = checkShowStatusText.IsChecked
        My.Settings.statusTextPos = comboStatusPosition.SelectedIndex
        My.Settings.showLast = checkShowLast.IsChecked
        My.Settings.smoothCursor = checkSmoothMouse.IsChecked
        My.Settings.cursorSpeed = slideSpeed.Value

        My.Settings.Threshold = slideThreshold.Value
        My.Settings.quickPlay = checkQuickPlay.IsChecked
        My.Settings.playAudio = checkPlayAudio.IsChecked

        My.Settings.toggleOrPTT = radioPTT.IsChecked
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub slideThreshold_ValueChanged(sender As Object, e As System.Windows.RoutedPropertyChangedEventArgs(Of Double))
        If Not IsNothing(labelThreshold) Then _
            labelThreshold.Content = Convert.ToInt32(slideThreshold.Value).tostring.trim & "%"
    End Sub

    Private Sub checkShowStatusText_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        comboStatusPosition.IsEnabled = checkShowStatusText.IsChecked
        checkShowLast.IsEnabled = checkShowStatusText.IsChecked
    End Sub

    Private Sub Hyperlink_Click(sender As Object, e As System.Windows.RoutedEventArgs)
        Process.Start("https://github.com/topher-au/HDT-Voice/")
    End Sub
End Class