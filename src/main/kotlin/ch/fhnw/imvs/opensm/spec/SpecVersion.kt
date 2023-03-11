package ch.fhnw.imvs.opensm.spec

import io.github.z4kn4fein.semver.Version
import io.github.z4kn4fein.semver.toVersion


object V0_0_8 : SpecVersion("0.0.8")
object V0_0_10 : SpecVersion("0.0.10")


typealias SupportedSpecRange = Pair<SpecVersion, SpecVersion>

fun SupportedSpecRange.isSupportedSpecVersion(version: String) =
    version.toVersion() in first.version..second.version

sealed class SpecVersion(private val value: String, val version: Version = value.toVersion()) {

    val patch = version.patch
    val major = version.major
    val minor = version.minor
    val isStable = version.isStable

    override fun toString() = version.toString()
}


