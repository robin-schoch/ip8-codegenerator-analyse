package ch.fhnw.imvs.mustache

import app.cash.barber.models.DocumentData
import java.time.Instant

data class RecipientReceipt(
    val sender: String,
    val amount: String,
    val cancelUrl: String,
    val deposit_expected_at: Instant
) : DocumentData