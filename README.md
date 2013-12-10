Spectral-Response-AQ
====================

The software that drives Bentham monochromators and SignalRecovery lock-in amplifiers to measure spectral responses

It currently supports

  1. Bentham TMc300 monochromator
  2. Signal Recovery lock-in ampifier (through NI VISA-USB interface)
  3. Older Bentham monochromator (through NI-VISA interface)


Prerequisites for building the software
==================================================

  - Visual studio 2010 or visual C# express 2010
  - .NET framework 4.0
  - only support 32-bit Windows OS, 
  - National instrument NI488.2 driver (NI 488.2.3.x), with .NET 4.0 support
    (http://sine.ni.com/psp/app/doc/p/id/psp-356)
  - National instrument NI-VISA driver (v5.3 or v5.4), with .NET 4.0 support
    (http://sine.ni.com/psp/app/doc/p/id/psp-411)
  - The .dll files that required to run TMc300 monochromator is already included in the project directory
  
  

