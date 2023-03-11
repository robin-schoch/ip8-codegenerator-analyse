/**
 *
 * Please note:
 * This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * Do not edit this file manually.
 *
 */

@file:Suppress(
    "ArrayInDataClass",
    "EnumEntryName",
    "RemoveRedundantQualifierName",
    "UnusedImport"
)

package org.openapitools.client.models


import com.squareup.moshi.Json

/**
 * Day of execution as string.   This string consists of up two characters. Leading zeroes are not allowed.   31 is ultimo of the month. 
 *
 * Values: _1,_2,_3,_4,_5,_6,_7,_8,_9,_10,_11,_12,_13,_14,_15,_16,_17,_18,_19,_20,_21,_22,_23,_24,_25,_26,_27,_28,_29,_30,_31
 */

enum class DayOfExecution(val value: kotlin.String) {

    @Json(name = "1")
    _1("1"),

    @Json(name = "2")
    _2("2"),

    @Json(name = "3")
    _3("3"),

    @Json(name = "4")
    _4("4"),

    @Json(name = "5")
    _5("5"),

    @Json(name = "6")
    _6("6"),

    @Json(name = "7")
    _7("7"),

    @Json(name = "8")
    _8("8"),

    @Json(name = "9")
    _9("9"),

    @Json(name = "10")
    _10("10"),

    @Json(name = "11")
    _11("11"),

    @Json(name = "12")
    _12("12"),

    @Json(name = "13")
    _13("13"),

    @Json(name = "14")
    _14("14"),

    @Json(name = "15")
    _15("15"),

    @Json(name = "16")
    _16("16"),

    @Json(name = "17")
    _17("17"),

    @Json(name = "18")
    _18("18"),

    @Json(name = "19")
    _19("19"),

    @Json(name = "20")
    _20("20"),

    @Json(name = "21")
    _21("21"),

    @Json(name = "22")
    _22("22"),

    @Json(name = "23")
    _23("23"),

    @Json(name = "24")
    _24("24"),

    @Json(name = "25")
    _25("25"),

    @Json(name = "26")
    _26("26"),

    @Json(name = "27")
    _27("27"),

    @Json(name = "28")
    _28("28"),

    @Json(name = "29")
    _29("29"),

    @Json(name = "30")
    _30("30"),

    @Json(name = "31")
    _31("31");

    /**
     * Override toString() to avoid using the enum variable name as the value, and instead use
     * the actual value defined in the API spec file.
     *
     * This solves a problem when the variable name and its value are different, and ensures that
     * the client sends the correct enum values to the server always.
     */
    override fun toString(): String = value

    companion object {
        /**
         * Converts the provided [data] to a [String] on success, null otherwise.
         */
        fun encode(data: kotlin.Any?): kotlin.String? = if (data is DayOfExecution) "$data" else null

        /**
         * Returns a valid [DayOfExecution] for [data], null otherwise.
         */
        fun decode(data: kotlin.Any?): DayOfExecution? = data?.let {
          val normalizedData = "$it".lowercase()
          values().firstOrNull { value ->
            it == value || normalizedData == "$value".lowercase()
          }
        }
    }
}

