import pyotp
totp = pyotp.TOTP("JSSWY3DPEHPK3PXP")
print("Current OTP:", totp.now())