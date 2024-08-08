from onvif import ONVIFCamera

class Onvif:
    def connect(ip: str, port: int, usr: str, pswd: str):
        try:
            camera = ONVIFCamera(host=ip, port=port, user=usr, passwd=pswd)
            media_service = camera.create_media_service()
            profiles = media_service.GetProfiles()
        except Exception:
              return 1
        return profiles, 0

    def onvifbrutforce(): pass

Onvif.connect("192.168.1.19", 80, "mohammed", "0000")
