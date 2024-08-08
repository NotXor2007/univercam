import clr, os
import multiprocessing

os.environ['PYTHONNET_RUNTIME'] = 'coreclr'
os.environ['PYTHONNET_CORE_RUNTIME'] = r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319'

clr.AddReference(".\\core\\engine\\engine")
from Engines import AutomaticGenerate
#from Utilities import*

def fetchdata():
    f = open(".\\ipgens.dat","r")
    while True:
        print(f.readline())


def genprocess():
    gen = AutomaticGenerate(".\\ipgens.dat");gen.GenerateIp()

if __name__ == "__main__":
    p1 = multiprocessing.Process(target=genprocess)
    p2 = multiprocessing.Process(target=fetchdata)
    p1.start()
    p2.start()
    while True:continue
    
    
    
