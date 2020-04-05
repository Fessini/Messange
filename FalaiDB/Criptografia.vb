Imports System
Imports System.Text
Imports System.Security.Cryptography

Namespace MODULO_CONFIGURACOES

    Public Class Criptografia

#Region "Funções e Subrotinas"
        ' <summary>
        ' Gera um hash para o texto fornecido e retorna o resultado base64-encoded. 
        ' Se não for gerado um Salto, ele será gerado automaticamente', e é usado no final do hash
        ' </summary>
        ' <param name="plainText">
        ' É o texto que será gerado o hash
        ' </param>
        ' < name="hashAlgorithm">
        ' Nome do algoritimo usado pra gerar o hash. "MD5", "SHA1","SHA256", "SHA384", e "SHA512" 
        ' Se qualquer outro valor for especificado. MD5 será usado). Estes valores são Case sensitive.
        ' </param>
        ' < name="saltBytes">
        ' Salt . Este valor pode ser nulo, e assim gerando um salto ramdomico
        ' </param>
        ' <returns>
        ' String com o hash gerado
        ' </returns>
        Public Shared Function ComputeHash(ByVal plainText As String, ByVal hashAlgorithm As String, ByVal saltBytes() As Byte) As String

            ' If salt is not specified, generate it on the fly.
            If (saltBytes Is Nothing) Then

                ' Define min and max salt sizes.
                Dim minSaltSize As Integer
                Dim maxSaltSize As Integer

                minSaltSize = 4
                maxSaltSize = 8

                ' Generate a random number for the size of the salt.
                Dim random As Random
                random = New Random()

                Dim saltSize As Integer
                saltSize = random.Next(minSaltSize, maxSaltSize)

                ' Allocate a byte array, which will hold the salt.
                saltBytes = New Byte(saltSize - 1) {}

                ' Initialize a random number generator.
                Dim rng As RNGCryptoServiceProvider
                rng = New RNGCryptoServiceProvider()

                ' Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes)
            End If

            ' Convert plain text into a byte array.
            Dim plainTextBytes As Byte()
            plainTextBytes = Encoding.UTF8.GetBytes(plainText)

            ' Allocate array, which will hold plain text and salt.
            Dim plainTextWithSaltBytes() As Byte = _
                New Byte(plainTextBytes.Length + saltBytes.Length - 1) {}

            ' Copy plain text bytes into resulting array.
            Dim I As Integer
            For I = 0 To plainTextBytes.Length - 1
                plainTextWithSaltBytes(I) = plainTextBytes(I)
            Next I

            ' Append salt bytes to the resulting array.
            For I = 0 To saltBytes.Length - 1
                plainTextWithSaltBytes(plainTextBytes.Length + I) = saltBytes(I)
            Next I

            ' Because we support multiple hashing algorithms, we must define
            ' hash object as a common (abstract) base class. We will specify the
            ' actual hashing algorithm class later during object creation.
            Dim hash As HashAlgorithm

            ' Make sure hashing algorithm name is specified.
            If (hashAlgorithm Is Nothing) Then
                hashAlgorithm = ""
            End If

            ' Initialize appropriate hashing algorithm class.
            Select Case hashAlgorithm.ToUpper()

                Case "SHA1"
                    hash = New SHA1Managed()

                Case "SHA256"
                    hash = New SHA256Managed()

                Case "SHA384"
                    hash = New SHA384Managed()

                Case "SHA512"
                    hash = New SHA512Managed()

                Case Else
                    hash = New MD5CryptoServiceProvider()

            End Select

            ' Compute hash value of our plain text with appended salt.
            Dim hashBytes As Byte()
            hashBytes = hash.ComputeHash(plainTextWithSaltBytes)

            ' Create array which will hold hash and original salt bytes.
            Dim hashWithSaltBytes() As Byte = _
                                       New Byte(hashBytes.Length + _
                                                saltBytes.Length - 1) {}

            ' Copy hash bytes into resulting array.
            For I = 0 To hashBytes.Length - 1
                hashWithSaltBytes(I) = hashBytes(I)
            Next I

            ' Append salt bytes to the result.
            For I = 0 To saltBytes.Length - 1
                hashWithSaltBytes(hashBytes.Length + I) = saltBytes(I)
            Next I

            ' Convert result into a base64-encoded string.
            Dim hashValue As String
            hashValue = Convert.ToBase64String(hashWithSaltBytes)

            ' Return the result.
            ComputeHash = hashValue
        End Function

        ' <summary>
        ' Compares a hash of the specified plain text value to a given hash
        ' value. Plain text is hashed with the same salt value as the original
        ' hash.
        ' </summary>
        ' <param name="plainText">
        ' Plain text to be verified against the specified hash. The function
        ' does not check whether this parameter is null.
        ' </param>
        ' < name="hashAlgorithm">
        ' Name of the hash algorithm. Allowed values are: "MD5", "SHA1",
        ' "SHA256", "SHA384", and "SHA512" (if any other value is specified
        ' MD5 hashing algorithm will be used). This value is case-insensitive.
        ' </param>
        ' < name="hashValue">
        ' Base64-encoded hash value produced by ComputeHash function. This value
        ' includes the original salt appended to it.
        ' </param>
        ' <returns>
        ' If computed hash mathes the specified hash the function the return
        ' value is true; otherwise, the function returns false.
        ' </returns>
        Public Shared Function VerifyHash(ByVal plainText As String, ByVal hashAlgorithm As String, ByVal hashValue As String) As Boolean

            ' Convert base64-encoded hash value into a byte array.
            Dim hashWithSaltBytes As Byte()
            hashWithSaltBytes = Convert.FromBase64String(hashValue)

            ' We must know size of hash (without salt).
            Dim hashSizeInBits As Integer
            Dim hashSizeInBytes As Integer

            ' Make sure that hashing algorithm name is specified.
            If (hashAlgorithm Is Nothing) Then
                hashAlgorithm = ""
            End If

            ' Size of hash is based on the specified algorithm.
            Select Case hashAlgorithm.ToUpper()
                Case "SHA1"
                    hashSizeInBits = 160
                Case "SHA256"
                    hashSizeInBits = 256
                Case "SHA384"
                    hashSizeInBits = 384
                Case "SHA512"
                    hashSizeInBits = 512
                Case Else ' Must be MD5
                    hashSizeInBits = 128
            End Select

            ' Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8

            ' Make sure that the specified hash value is long enough.
            If (hashWithSaltBytes.Length < hashSizeInBytes) Then
                VerifyHash = False
            End If

            ' Allocate array to hold original salt bytes retrieved from hash.
            Dim saltBytes() As Byte = New Byte(hashWithSaltBytes.Length - hashSizeInBytes - 1) {}

            ' Copy salt from the end of the hash to the new array.
            Dim I As Integer
            For I = 0 To saltBytes.Length - 1
                saltBytes(I) = hashWithSaltBytes(hashSizeInBytes + I)
            Next I

            ' Compute a new hash string.
            Dim expectedHashString As String
            expectedHashString = ComputeHash(plainText, hashAlgorithm, saltBytes)

            ' If the computed hash matches the specified hash,
            ' the plain text value must be correct.
            VerifyHash = (hashValue = expectedHashString)
        End Function

        Sub main()

            Dim password As String    ' original password
            Dim wrongPassword As String    ' wrong password

            password = "myP@5sw0rd"
            wrongPassword = "password"

            Dim passwordHashMD5 As String
            Dim passwordHashSha1 As String
            Dim passwordHashSha256 As String
            Dim passwordHashSha384 As String
            Dim passwordHashSha512 As String

            passwordHashMD5 = ComputeHash(password, "MD5", Nothing)
            passwordHashSha1 = ComputeHash(password, "SHA1", Nothing)
            passwordHashSha256 = ComputeHash(password, "SHA256", Nothing)
            passwordHashSha384 = ComputeHash(password, "SHA384", Nothing)
            passwordHashSha512 = ComputeHash(password, "SHA512", Nothing)

            Console.WriteLine("COMPUTING HASH VALUES")
            Console.WriteLine("")
            Console.WriteLine("MD5   : {0}", passwordHashMD5)
            Console.WriteLine("SHA1  : {0}", passwordHashSha1)
            Console.WriteLine("SHA256: {0}", passwordHashSha256)
            Console.WriteLine("SHA384: {0}", passwordHashSha384)
            Console.WriteLine("SHA512: {0}", passwordHashSha512)
            Console.WriteLine("")

            Console.WriteLine("COMPARING PASSWORD HASHES")
            Console.WriteLine("")
            Console.WriteLine("MD5    (good): {0}", VerifyHash(password, "MD5", passwordHashMD5).ToString())
            Console.WriteLine("MD5    (bad) : {0}", VerifyHash(wrongPassword, "MD5", passwordHashMD5).ToString())
            Console.WriteLine("SHA1   (good): {0}", VerifyHash(password, "SHA1", passwordHashSha1).ToString())
            Console.WriteLine("SHA1   (bad) : {0}", VerifyHash(wrongPassword, "SHA1", passwordHashSha1).ToString())
            Console.WriteLine("SHA256 (good): {0}", VerifyHash(password, "SHA256", passwordHashSha256).ToString())
            Console.WriteLine("SHA256 (bad) : {0}", VerifyHash(wrongPassword, "SHA256", passwordHashSha256).ToString())
            Console.WriteLine("SHA384 (good): {0}", VerifyHash(password, "SHA384", passwordHashSha384).ToString())
            Console.WriteLine("SHA384 (bad) : {0}", VerifyHash(wrongPassword, "SHA384", passwordHashSha384).ToString())
            Console.WriteLine("SHA512 (good): {0}", VerifyHash(password, "SHA512", passwordHashSha512).ToString())
            Console.WriteLine("SHA512 (bad) : {0}", VerifyHash(wrongPassword, "SHA512", passwordHashSha512).ToString())

        End Sub


        Private Function GerarSalt(ByVal intMinimo As Integer, ByVal intMaximo As Integer) As String

            Dim saltLen As Integer = 0
            saltLen = GerarNumeroRandomico(intMinimo, intMaximo)

            Dim salt() As Byte = New Byte(saltLen - 1) {}

            ' Populate salt with cryptographically strong bytes.
            Dim rng As Security.Cryptography.RNGCryptoServiceProvider = New Security.Cryptography.RNGCryptoServiceProvider()

            rng.GetNonZeroBytes(salt)

            ' Split salt length (always one byte) into four two-bit pieces and
            ' store these pieces in the first four bytes of the salt array.
            salt(0) = ((salt(0) And &HFC) Or (saltLen And &H3))
            salt(1) = ((salt(1) And &HF3) Or (saltLen And &HC))
            salt(2) = ((salt(2) And &HCF) Or (saltLen And &H30))
            salt(3) = ((salt(3) And &H3F) Or (saltLen And &HC0))

            Return Convert.ToBase64String(salt)

        End Function

        Private Function GerarNumeroRandomico(ByVal minValue As Integer, _
                                         ByVal maxValue As Integer) As Integer

            ' We will make up an integer seed from 4 bytes of this array.
            Dim randomBytes() As Byte = New Byte(3) {}

            ' Generate 4 random bytes.
            Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
            rng.GetBytes(randomBytes)

            ' Convert four random bytes into a positive integer value.
            Dim seed As Integer = ((randomBytes(0) And &H7F) << 24) Or (randomBytes(1) << 16) Or (randomBytes(2) << 8) Or (randomBytes(3))

            ' Now, this looks more like real randomization.
            Dim random As Random = New Random(seed)

            ' Calculate a random number.
            GerarNumeroRandomico = random.Next(minValue, maxValue + 1)
        End Function

#End Region

    End Class
End Namespace
