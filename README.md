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

