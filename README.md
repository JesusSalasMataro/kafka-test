### Installing confluent Kafka on Mac

1. Install brew for Mac. Open terminal and write:

	/usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"

2. Install librdkafka lib:

	brew install librdkafka


3. Install nuget Confluent Kafka in C# project
    
<br/>
  
### Run Kafka

1. Run in terminal:

	zookeeper-server-start /usr/local/etc/kafka/zookeeper.properties

	kafka-server-start /usr/local/etc/kafka/server.properties
	
<br/>

### Notes

"librdkafka" is a library writen in C language that communicates with Kafka. The confluent kafka nuget is like a wrapper that uses this library, that is why it is mandatory to install the library before using the nuget.

Confluent kafka divides topic partitions between the configured consumers in our code. We can test this behaviour adding or removing consumers in the example. So we can have a 1:1 relation between the partitions of a topic and the consumers or not, it is our decission.


