Namespace Commons
    
    public class OnvifCommons
        private Dim _CommonPorts as Integer() = {80, 443, 554, 8080, 8888, 4444}
    
        public Sub New()
         End Sub

        public ReadOnly Property GetCommonPorts() As Integer()
             Get
                Return _CommonPorts
            End Get
        End Property
        
    End Class

    public class RTSPCommons
    End Class
End Namespace
