package ch.fhnw.imvs.statemachine;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.statemachine.action.Action;
import org.springframework.statemachine.config.EnableStateMachine;
import org.springframework.statemachine.config.StateMachineConfigurerAdapter;
import org.springframework.statemachine.config.builders.StateMachineStateConfigurer;
import org.springframework.statemachine.config.builders.StateMachineTransitionConfigurer;


@Configuration
@EnableStateMachine
public class BridgeConfiguration extends StateMachineConfigurerAdapter<BridgeState, BridgeEvent> {

    @Override
    public void configure(StateMachineStateConfigurer<BridgeState, BridgeEvent> states) throws Exception {
        states
            .withStates()
            .states(EnumSet.allOf(BridgeState.class))
            .stateEntry(BridgeState.OPEN, executeOpenAction())
            .stateEntry(BridgeState.CLOSED, executeClosedAction())
            .initial(BridgeState.OPEN);
    }

    @Override
    public void configure(StateMachineTransitionConfigurer<BridgeState, BridgeEvent> transitions) throws Exception {
        transitions
                   .withExternal().source(BridgeState.OPEN)
                                  .target(BridgeState.CLOSED)
                                  .event(BridgeEvent.ONCLOSE)
                                  .action(executeEventOnCloseFromOpenToClosedAction())
                   .and()
;
    }

    @Bean
    public Action<BridgeState, BridgeEvent> executeOpenAction() {
        return ctx -> { /* TODO */ };
    }
    @Bean
    public Action<BridgeState, BridgeEvent> executeClosedAction() {
        return ctx -> { /* TODO */ };
    }

    @Bean
    public Action<BridgeState, BridgeEvent> executeEventOnCloseFromOpenToClosedAction() {
        return ctx -> { /* TODO */ };
    }
}