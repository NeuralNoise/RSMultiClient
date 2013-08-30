﻿Module modMisc
    Public Function FormatBytes(ByVal dblbytes As Double, Optional ByVal strFormated As String = "0.00") As String
        Dim arrPosForm() As String = {"Bytes", "Kilobyte", "Megabyte", "Gigabyte", _
            "Terabyte", "Petabyte", "Exabyte", "Zettabyte", "Yottabyte"}
        For i As Integer = arrPosForm.Length - 1 To 0 Step -1
            If dblbytes > 1024 ^ i Then
                dblbytes /= 1024 ^ i
                Return dblbytes.ToString(strFormated) & " " & _
                    arrPosForm(i)
            End If
        Next i

        Return dblbytes.ToString(strFormated) & " Bytes"
    End Function

    Public Function FormatBytesPerSec(ByVal dblbytes As Double, Optional ByVal strFormated As String = "0.00") As String
        Dim arrPosForm() As String = {"B/s", "KiB/s", "MiB/s", "GiB/s", _
            "TiB/s", "PiB/s", "ExiB/s", "ZiB/s", "YiB/s"}
        For i As Integer = arrPosForm.Length - 1 To 0 Step -1
            If dblbytes > 1024 ^ i Then
                dblbytes /= 1024 ^ i
                Return dblbytes.ToString(strFormated) & " " & _
                    arrPosForm(i)
            End If
        Next i

        Return dblbytes.ToString(strFormated) & " Bytes"
    End Function

    Public Function NetStatus2String(netStatusID As UInteger) As String
        Select Case netStatusID
            Case 0
                Return "BAD: Unknown"
            Case 1
                Return "BAD: Offline"
            Case 2
                Return "BAD: symmetric NAT"
            Case 3
                Return "BAD: No DHT, NATted"
            Case 4
                Return "Warning: Restart"
            Case 5
                Return "Warning: NATted"
            Case 6
                Return "Warning: No DHT"
            Case 7
                Return "Good!"
            Case 8
                Return "Adv. Forward"
            Case Else
                Return "UNK: Unkown"
        End Select
    End Function

    Public Function SplitString(ByVal strText As String, ByVal strChars As String, ByVal Mode As Integer) As String

        ' String in zwei Teile splitten
        ' und entweder linken Teil (Mode = 1)
        ' oder rechten Teil (Mode = 2) zurückgeben

        Dim sPos As Long

        sPos = InStr(strText, strChars)
        If sPos > 0 Then
            ' strChars ist in strText enthalten
            If Mode = 1 Then
                ' linke Teilstring zurückgeben
                SplitString = Left$(strText, sPos - 1)
            Else
                ' rechten Teilstring zurückgeben
                SplitString = Mid$(strText, sPos + Len(strChars))
            End If
        Else
            ' strChars ist in strText nicht enthalten
            SplitString = ""
        End If
    End Function

    ''' <summary>
    ''' Fügt dem ListView eine komplette Datenzeile hinzu
    ''' </summary>
    ''' <param name="lvw">ListView-Control</param>
    ''' <param name="Text">Parameterliste der einzelnen Zellenwerte</param>
    Public Sub lvwAddItem(ByVal lvw As ListView, ByVal ParamArray Text() As String)
        With lvw.Items
            .Add(New ListViewItem(Text))
        End With
    End Sub
End Module