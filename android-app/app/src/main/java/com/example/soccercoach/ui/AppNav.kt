
package com.example.soccercoach.ui

import androidx.compose.runtime.Composable
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import com.example.soccercoach.ui.screens.HomeScreen
import com.example.soccercoach.ui.screens.PlayersScreen
import com.example.soccercoach.ui.screens.MatchScreen

@Composable
fun AppNav() {
    val nav = rememberNavController()
    NavHost(navController = nav, startDestination = "home") {
        composable("home") {
            HomeScreen(
                onPlayers = { nav.navigate("players") },
                onMatch = { nav.navigate("match") }
            )
        }
        composable("players") { PlayersScreen(onBack = { nav.popBackStack() }) }
        composable("match") { MatchScreen(onBack = { nav.popBackStack() }) }
    }
}
