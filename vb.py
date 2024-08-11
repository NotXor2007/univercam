import clr, os
import multiprocessing

os.environ['PYTHONNET_RUNTIME'] = 'coreclr'
os.environ['PYTHONNET_CORE_RUNTIME'] = r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319'

clr.AddReference(".\\core\\engine\\engine")
from Engines import AutomaticGenerate

def genprocess():
    gen = AutomaticGenerate(".\\ipgens.dat");gen.GenerateIp()

#EntryPoint
if __name__ == "__main__":
    #p1 = multiprocessing.Process(target=genprocess)
    #p1.start()
    gen = AutomaticGenerate(".\\ipgens.dat");
    gen.GenerateIp()
    while True:print("running")
    
