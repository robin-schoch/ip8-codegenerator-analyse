package ch.fhnw.imvs.spring.test;

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
public class WaterModelConfiguration extends StateMachineConfigurerAdapter<WaterModelState, WaterModelEvent> {

    @Override
    public void configure(StateMachineStateConfigurer<WaterModelState, WaterModelEvent> states) throws Exception {
        states
                .withStates()
                .states(EnumSet.allOf(WaterModelState.class))
                .stateEntry(WaterModelState.LIQUIDE, executeLiquideAction())
                .stateEntry(WaterModelState.FROZEN, executeFrozenAction())
                .initial(WaterModelState.LIQUIDE);
    }

    @Override
    public void configure(StateMachineTransitionConfigurer<WaterModelState, WaterModelEvent> transitions) throws Exception {
        transitions
                .withExternal().source(WaterModelState.LIQUIDE)
                .target(WaterModelState.FROZEN)
                .event(WaterModelEvent.ONFROZEN)
                .action(executeEventOnFrozenFromLiquideToFrozenAction())
                .and()
                .withExternal().source(WaterModelState.FROZEN)
                .target(WaterModelState.LIQUIDE)
                .event(WaterModelEvent.ONMELTED)
                .action(executeEventOnMeltedFromFrozenToLiquideAction())
                .and()
        ;
    }

    @Bean
    public Action<WaterModelState, WaterModelEvent> executeLiquideAction() {
        return ctx -> { /* TODO */ };
    }

    @Bean
    public Action<WaterModelState, WaterModelEvent> executeFrozenAction() {
        return ctx -> { /* TODO */ };
    }

    @Bean
    public Action<WaterModelState, WaterModelEvent> executeEventOnFrozenFromLiquideToFrozenAction() {
        return ctx -> { /* TODO */ };
    }

    @Bean
    public Action<WaterModelState, WaterModelEvent> executeEventOnMeltedFromFrozenToLiquideAction() {
        return ctx -> { /* TODO */ };
    }
}