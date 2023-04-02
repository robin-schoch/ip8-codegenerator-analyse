package ch.fhnw.imvs.spring;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.statemachine.action.Action;
import org.springframework.statemachine.config.EnableStateMachine;
import org.springframework.statemachine.config.StateMachineConfigurerAdapter;
import org.springframework.statemachine.config.builders.StateMachineStateConfigurer;
import org.springframework.statemachine.config.builders.StateMachineTransitionConfigurer;

import java.util.EnumSet;


@Configuration
@EnableStateMachine
public class SimpleStateMachineConfiguration
        extends StateMachineConfigurerAdapter<WaterModelStates, WaterModelEvents> {

    @Override
    public void configure(StateMachineStateConfigurer<WaterModelStates, WaterModelEvents> states)
            throws Exception {

        states
                .withStates()
                .states(EnumSet.allOf(WaterModelStates.class))
                .initial(WaterModelStates.LIQUIDE)
                .stateEntry(WaterModelStates.LIQUIDE, executeAction());

    }

    @Override
    public void configure(
            StateMachineTransitionConfigurer<WaterModelStates, WaterModelEvents> transitions
    ) throws Exception {
        transitions
                .withExternal()
                .source(WaterModelStates.LIQUIDE)
                .target(WaterModelStates.FROZEN)
                .event(WaterModelEvents.ON_FROZEN)
                .action(executeAction());
    }


    @Bean
    public Action<WaterModelStates, WaterModelEvents> executeAction() {
        return ctx -> System.out.println("Do" + ctx.getTarget().getId());
    }
}