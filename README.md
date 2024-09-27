Interactive Photo Frame in VR using Unity
_________________________________________

To Run the Direct APK File:

  1. Download the RecruitmentTask_posibabu.apk file from the APK folder.
  2. Install the downloaded APK file on your Oculus Quest, Quest 2, or Quest 3 (tested on Quest 2) using SideQuest or your preferred method.
  3. After successfully installing the APK, download the Images RAR file, extract it, and place the images in the application’s persistent path.

To Run in the Editor:

  1. Open the Unity project using Unity version 2021.3.40.
  2. Download the Images RAR file, extract it, and place the images in the application’s persistent path( generally, C:/Users/[YourUsername]/AppData/LocalLow/DefaultCompany/InteractivePhotoFrame_VR/).
  3. To test in the editor without a VR headset, enable the XR Device Simulator:
  4. Go to Project Settings > XR Plugin Management > XR Interaction Toolkit and enable XR Device Simulator.
  5. To test with a VR headset, please disable the XR Device Simulator option.
     
Functionalities:

  1. When you run the application in a VR headset, it will load a scene with a room, a photo frame on the wall, and two UI buttons: Change Photo and Float.
  2. Change Photo: This button allows you to switch between photos that you've added in the persistent path. User can interact with this by using trigger button on any controller
  3. If no photos are available in the persistent path, a popup will be displayed on the wall indicating that no photos are available to load.
  4. Float Button: This button enables the photo frame to float in the air. Click it again to return the frame to its original position and angle. User can interact with this by using trigger button on any controller
  5. Using the controller's Grip buttons, you can grab the photo frame, and rotate, scale, or change its position.
  6. Users can teleport anywhere on the floor using the teleport option in the Oculus interface.
