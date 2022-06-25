
# Verificoder

Generate your costumized Verification Code on .Net Cor.

In some cases you need to create random numbers between 4 and 8 digits, so this package helps you to have a general code generator for all parts of your program in the .NET modular structure.




## Authors

- [@thisisnabi](https://www.github.com/thisisnabi)




## Features (Configuration)

- Code Length 
- Count of digit repeatation 
- DI (IVerificoder)
- Use Group Code (coming soon)


## Install

Install with Package Manager Console  

```bash
  Install-Package Verificoder
```


## Add/DI

```csharp
// default configuration
services.AddVerificoder();
```

```csharp
// if you want use customize setting
services.AddVerificoder(options => {
      options.StartWithZero = true; // default is false 
      options.DefaultLength = 5; // default is 5
      options.DefualtMaxRepeatNumber = 2; // default is 1
});
```


## Usage/Example
```csharp
private readonly IVerificoder _verificoder;

public AccountController(IVerificoder verificoder)
{
    _verificoder = verificoder;
}

private IActionResult SendVerifyCode(string phone)
{
    var verifyCode = _verificoder.TakeOne();

    var result _smsService.SendSms(phone, $"you account verification code is :{verifyCode}");

    return Ok();
}
```


## Inline/Configuration
```csharp
// length 7 and default max repeat(1)
var verifyCode = _verificoder.TakeOne(7);

// length 7 and max repeat(3)
var verifyCode = _verificoder.TakeOne(7,3);
```
