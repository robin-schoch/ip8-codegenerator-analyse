package ch.fhnw.imvs.spring.test;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class ApplicationRunner implements CommandLineRunner {

    @Autowired
    private BridgeConfiguration bridgeConfiguration;
    @Autowired
    private WaterModelConfiguration waterModelConfiguration;

    public static void main(String[] args) {
        SpringApplication.run(ApplicationRunner.class, args);
    }

    @Override
    public void run(String... args) throws Exception {

    }
}