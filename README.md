# EFS

*Disclaimer - under the hood this is a piece of horribly written software. Still I decided to showcase it (together with [CzasPracy](https://github.com/morbidreich/CzasPracy)) to present my ability to deliver succesful and highly useful solutions in accordance with customer specifications. Also - that was 10 years ago:) If you've flown from Poland in last 10 years it's almost certain that controller that was watching after you from tower was trained using my software.*

### Application domain

Flight Strips - tiny strips of paper printed with details of each flight arriving or departing from airport. It's essential and one of the most important tools (next to eyesight and radio) of every tower air traffic controller. Using flight strips we can track position of airplanes, quickly check flight details, write down issued clearances and instructions, to name a few. With a bit of practice they easily translate into 3D mind picture of situation at and around aerodrome. 

As you can imagine, progress of technology allowed to digitalize good old paper strips and move them to interactive screens. Same happened in Poland around 2012. Such a significant change in work technique had to entrail retraining of staff. 

<img height="200" src="https://user-images.githubusercontent.com/58663723/148106899-b5659c42-3eff-4ed3-a1a8-e7415e1d979c.jpg"> <img height="200"  src="https://user-images.githubusercontent.com/58663723/148108059-34201d9a-7202-41f2-afc5-6a9d9b34df1a.jpg">

[PANSA](https://www.pansa.pl) has its own training centre intended exactly for tasks like that. Howewer there was a problem with its simulator system. While it had capacity to retrain controllers using electronic flight strips, its software functionalities significantly differed from real life counterpart provided by Spanish company - [Indra Sistemas](https://www.indracompany.com/). As a former training centre employee I decided to get involved and offered to write my own solution that would connect existing simulator infrastructure and databases with look, feel and workflow of soon-to-be-implemented Spanish system. After few months of development application was ready

### Core features
* Visual interface and functionalities imitating target system
* Integration with training simulator database
* Multi position training - connection via LAN

### Technologies

* Plain old C#
* Database integration comes down to parsing *really* lot of text files containing airspace data, exercises data and airplane performance. 



<img alt="EFS" width="250" src="https://user-images.githubusercontent.com/58663723/148121443-ca753f10-26f4-4ac9-ab70-d7a826cc1d07.png"> <img alt="Sim" width="250" src="https://user-images.githubusercontent.com/58663723/148122737-d2a0005f-04b3-4a47-88d1-51e1be43139d.jpg">



