Namespace Items.KeyItems

    <Item(6, "Bicycle")>
    Public Class Bicycle

        Inherits KeyItem

        Public Overrides ReadOnly Property Description As String = "A folding Bicycle that enables much faster movement than the Running Shoes."

        Public Sub New()
            _textureRectangle = New Rectangle(120, 0, 24, 24)
        End Sub
        Public Overrides Sub Use()
            If Screen.Level.Biking = True Then
                Screen.Level.Biking = False
                Screen.Level.OwnPlayer.SetTexture(Core.Player.TempBikeSkin, True)
                Core.Player.Skin = Core.Player.TempBikeSkin

                If Core.CurrentScreen.Identification = Screen.Identifications.UseItemScreen Then
                    Core.SetScreen(Core.CurrentScreen.PreScreen)
                End If

                If Screen.Level.IsRadioOn = False OrElse GameJolt.PokegearScreen.StationCanPlay(Screen.Level.SelectedRadioStation) = False Then
                    MusicManager.Play(Screen.Level.MusicLoop)
                End If
            Else
                If Screen.Level.Surfing = False And Screen.Level.Biking = False And Screen.Level.Riding = False And Screen.Camera.IsMoving() = False And Screen.Camera.Turning = False And Screen.Level.CanBike() = True Then

                    If GameModeManager.ContentFileExists(Core.Player.Skin & "_Bike") = False Then
                        Screen.TextBox.Show("Your Player Skin doesn't support this item!", {}, True, False)
                    Else
                        If Core.CurrentScreen.Identification = Screen.Identifications.UseItemScreen Then
                            Core.SetScreen(Core.CurrentScreen.PreScreen)
                        End If

                        Screen.Level.Biking = True
                        Core.Player.TempBikeSkin = Core.Player.Skin

                        Dim BikeSkin As String = "[SKIN]"
                        BikeSkin = Core.Player.Skin & "_Bike"
                        Screen.Level.OwnPlayer.SetTexture(BikeSkin, False)
                    End If

                    SoundManager.PlaySound("bicycle")
                    PlayerStatistics.Track("Bike used", 1)

                    If Screen.Level.IsRadioOn = False OrElse GameJolt.PokegearScreen.StationCanPlay(Screen.Level.SelectedRadioStation) = False Then
                        MusicManager.Play("bikesong", True)
                    End If
                Else
                    Screen.TextBox.Show("Now is not the time~to use that.", {}, True, False)
                End If
            End If
        End Sub
    End Class

End Namespace
