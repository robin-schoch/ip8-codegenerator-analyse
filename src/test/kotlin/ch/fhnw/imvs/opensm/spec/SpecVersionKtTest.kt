package ch.fhnw.imvs.opensm.spec

import kotlin.test.Test
import kotlin.test.assertFails
import kotlin.test.assertFalse
import kotlin.test.assertTrue


internal class SpecVersionKtTest {

    private val specRange = V0_0_8 to V0_0_10

    @Test
    fun validVersion_validRange_isInRange() {
        assertTrue {
            specRange.isSupportedSpecVersion("0.0.9")
        }
    }

    @Test
    fun validVersion_validRange_isOutSideOfRange() {
        assertFalse {
            specRange.isSupportedSpecVersion("0.0.12")
        }
    }

    @Test
    fun validVersionAtUpperBound_validRange_isInRange() {
        assertTrue {
            specRange.isSupportedSpecVersion("0.0.10")
        }
    }


    @Test
    fun validVersionAtLowerBound_validRange_isInRange() {
        assertTrue {
            specRange.isSupportedSpecVersion("0.0.8")
        }
    }

    @Test
    fun invalidVersion_validRange_throwsException() {
        assertFails {
            specRange.isSupportedSpecVersion("12a2390120.-.12Invalid")
        }
    }
}
