
# Verificoder

Generate your customized Verification Code on .Net Core.

In some cases, you need to create random numbers between 4 and 8 digits, so this package helps you to have a general code generator for all parts of your program in the .NET modular structure.



## Authors

- [@thisisnabi](https://www.github.com/thisisnabi)




## Features (Configuration)

- Code Length 
- Max of digit repeatation 
- Global and Inline Configuration
- DI (IVerificoder)
- Caching the code by phone and validation it


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
      options.DefualtMaxRepeatNumber = 2; // default is 1,
      // if you want use scoped code
      options.ScopeCodeAbsoluteExpiration = TimeSpan.FromMinutes(2); // default is TimeSpan.FromMinutes(1) 
});
```


## Usage/Simple mode
```csharp
private readonly IVerificoder _verificoder;

public AccountController(IVerificoder verificoder)
{
    _verificoder = verificoder;
}

public IActionResult SendVerifyCode(string phone)
{
    var verifyCode = _verificoder.TakeOne();

    var result _smsService.SendSms(phone, $"your account verification code is :{verifyCode}");

    return Ok();
}
```


## Usage/Scoped Mode
```csharp
private readonly IVerificoder _verificoder;

public AccountController(IVerificoder verificoder)
{
    _verificoder = verificoder;
}

public IActionResult SendVerifyCode(string phone)
{
       // if last code not expired, you can't take new code.
       // you can set Expiration time when adding option to DI, [ScopeCodeAbsoluteExpiration]
       if (_verificoder.CanTakeOnScope(phone))
       {
           var verifyCode = _verificoder.TakeOnScope(phone);
                 
           var message = string
               .Format("your account verification code is :{0}", verifyCode);

           _smsService.SendSms(phone, message);

           return Ok("Code was Sent to the Phone number.");
       }
 
       return BadRequest("You can't ");
}


public IActionResult CreateAccount(string phone,string userValidationCode)
{

        if(!_verificoder.IsValidOnScope(phone,userValidationCode))
        {
            return BadRequest("Please enter valid codes.");
        }

       // other creation account code
}
```



## Inline/Configuration
```csharp
// length 7 and default max repeat(1)
var verifyCode = _verificoder.TakeOne(7);
// scoped mode
var verifyCode = _verificoder.TakeOnScope(phone,7);



// length 7 and max repeat(3)
var verifyCode = _verificoder.TakeOne(7,3);
// scoped mode
var verifyCode = _verificoder.TakeOnScope(phone,7,3);
```
