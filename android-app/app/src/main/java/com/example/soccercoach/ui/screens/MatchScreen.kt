
package com.example.soccercoach.ui.screens

import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp

@Composable
fun MatchScreen(onBack: () -> Unit) {
    Column(
        modifier = Modifier
            .fillMaxSize()
            .padding(16.dp),
        verticalArrangement = Arrangement.spacedBy(12.dp)
    ) {
        Text("New Match")
        Text("TODO: pick squad (max 16) from players database")
        Text("TODO: select starting 11 for Q1 using fixed 4-4-2 numbered slots")
        Text("TODO: generate plan for remaining quarters")
        Text("TODO: confirm substitutions individually; if any rejected, prompt to replan")
        Text("GK Rule: slot #1 can only swap with GK-eligible; if none, keep GK")

        Row(horizontalArrangement = Arrangement.spacedBy(8.dp)) {
            Button(onClick = onBack) { Text("Back") }
        }
    }
}
