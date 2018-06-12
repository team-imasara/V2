using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

// Token: 0x02000410 RID: 1040
public class SimpleEncryptStream : Stream
{
    // Token: 0x060020DD RID: 8413 RVA: 0x000BA074 File Offset: 0x000B8274
    public SimpleEncryptStream(Stream stream)
    {
        this.refenceStream = stream;
    }

    // Token: 0x060020DE RID: 8414 RVA: 0x000BA084 File Offset: 0x000B8284
    public void WriteHeader(string header)
    {
        if (header.Length < 16)
        {
            header = header.PadRight(16, '=');
        }
        else if (header.Length > 16)
        {
            header = header.Substring(0, 16);
        }
        byte[] bytes = Encoding.UTF8.GetBytes(header);
        MD5 md = new MD5CryptoServiceProvider();
        this.header = md.ComputeHash(bytes);
        this.headerLength = (this.encryptionLength = 16);
        this.refenceStream.Write(this.header, 0, 16);
    }

    // Token: 0x060020DF RID: 8415 RVA: 0x000BA10C File Offset: 0x000B830C
    public void ReadHeader()
    {
        this.header = new byte[16];
        this.refenceStream.Seek(0L, SeekOrigin.Begin);
        this.refenceStream.Read(this.header, 0, 16);
        this.headerLength = (this.encryptionLength = 16);
    }

    // Token: 0x060020E0 RID: 8416 RVA: 0x000BA15C File Offset: 0x000B835C
    public void SetManualHeader(byte[] header)
    {
        this.header = header;
        this.headerLength = 0;
        this.encryptionLength = header.Length;
    }

    // Token: 0x170005B2 RID: 1458
    // (get) Token: 0x060020E1 RID: 8417 RVA: 0x000BA178 File Offset: 0x000B8378
    public override bool CanRead
    {
        get
        {
            return this.refenceStream.CanRead;
        }
    }

    // Token: 0x170005B3 RID: 1459
    // (get) Token: 0x060020E2 RID: 8418 RVA: 0x000BA188 File Offset: 0x000B8388
    public override bool CanSeek
    {
        get
        {
            return this.refenceStream.CanSeek;
        }
    }

    // Token: 0x170005B4 RID: 1460
    // (get) Token: 0x060020E3 RID: 8419 RVA: 0x000BA198 File Offset: 0x000B8398
    public override bool CanWrite
    {
        get
        {
            return this.refenceStream.CanWrite;
        }
    }

    // Token: 0x170005B5 RID: 1461
    // (get) Token: 0x060020E4 RID: 8420 RVA: 0x000BA1A8 File Offset: 0x000B83A8
    public override long Length
    {
        get
        {
            return this.refenceStream.Length;
        }
    }

    // Token: 0x170005B6 RID: 1462
    // (get) Token: 0x060020E5 RID: 8421 RVA: 0x000BA1B8 File Offset: 0x000B83B8
    // (set) Token: 0x060020E6 RID: 8422 RVA: 0x000BA1C8 File Offset: 0x000B83C8
    public override long Position
    {
        get
        {
            return this.refenceStream.Position;
        }
        set
        {
            this.refenceStream.Position = value;
        }
    }

    // Token: 0x060020E7 RID: 8423 RVA: 0x000BA1D8 File Offset: 0x000B83D8
    public override void Flush()
    {
        this.refenceStream.Flush();
    }

    // Token: 0x060020E8 RID: 8424 RVA: 0x000BA1E8 File Offset: 0x000B83E8
    public override int Read(byte[] buffer, int offset, int count)
    {
        long position = this.Position;
        int num = this.refenceStream.Read(buffer, offset, count);
        int i = 0;
        int num2 = 0;
        while (i < num)
        {
            if (num2 == this.encryptionLength)
            {
                num2 = 0;
            }
            int num3 = (int)buffer[i + offset];
            int num4 = (int)this.header[num2];
            buffer[i + offset] = (byte)(num3 ^ num4);
            num2++;
            i++;
        }
        return num;
    }

    // Token: 0x060020E9 RID: 8425 RVA: 0x000BA250 File Offset: 0x000B8450
    public override long Seek(long offset, SeekOrigin origin)
    {
        return this.refenceStream.Seek(offset + (long)this.headerLength, origin);
    }

    // Token: 0x060020EA RID: 8426 RVA: 0x000BA268 File Offset: 0x000B8468
    public override void SetLength(long value)
    {
        this.refenceStream.SetLength(value);
    }

    // Token: 0x060020EB RID: 8427 RVA: 0x000BA278 File Offset: 0x000B8478
    public override void Write(byte[] buffer, int offset, int count)
    {
        int i = 0;
        int num = 0;
        while (i < count)
        {
            if (num == this.encryptionLength)
            {
                num = 0;
            }

            var temp = buffer[i + offset] ^ this.header[num];
            buffer[i + offset] = (byte)temp;
            num++;
            i++;
        }
        this.refenceStream.Write(buffer, offset, count);
    }

    // Token: 0x060020EC RID: 8428 RVA: 0x000BA2D0 File Offset: 0x000B84D0
    public override void Close()
    {
        this.refenceStream.Close();
    }

    // Token: 0x04002B67 RID: 11111
    private const int HEADER_LENGTH = 16;

    // Token: 0x04002B68 RID: 11112
    public Stream refenceStream;

    // Token: 0x04002B69 RID: 11113
    public byte[] header;

    // Token: 0x04002B6A RID: 11114
    private int headerLength;

    // Token: 0x04002B6B RID: 11115
    private int encryptionLength;
}
