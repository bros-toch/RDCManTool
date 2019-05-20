# RDCManTool

A quick tool to export/import RDC file created by (Remote Desktop Connection Manager) from one pc to another pc.

The certificate used to encrypt/descript are different between pcs. Copying a file from one pc to another pc will not work.

## QuickStart

### Export to another pc
```CMD> RDCManTool.Console.exe --in "RDC.rdg" --out "RDC.encrypted.rdg" --key "MyStrongEncryptedKey" --export```

What it does is to descrypt saved passwords using current pc's certificate and encrypt the passwords with the new key.

---
### Import to a pc
```CMD> RDCManTool.Console.exe --in "RDC.encrypted.rdg" --out "RDC.rdg" --key "MyStrongEncryptedKey" --import```

It will descrypt the passwords using the key used in previous export and then use the current pc's certiciate to encrypt password to be readable by the application.