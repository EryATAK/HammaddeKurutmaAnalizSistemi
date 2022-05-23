int olcum=A0;


void setup() 
{
  Serial.begin(9600);
}

void loop() 
{
  int deger=analogRead(olcum);
  Serial.println(deger);
  delay(100);
}
