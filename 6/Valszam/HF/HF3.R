deathCircle <- function(N) {
  reactions <- sample(1:N);
  #reactions <- N:1; # erdekes eset, mert igy csak 1 katona marad eletben
  
  soldiers <- rep(TRUE, N);
  
  for (reaction in reactions) {
    if (soldiers[reaction]) {
      soldiers[(reaction %% N) + 1] <- FALSE;
    }
  }
  
  return(sum(soldiers));
}

avarage <- function(N, M) {
  result <- rep(0, M);
  
  for (i in 1:M) {
    result[i] <- deathCircle(N);
  }
  
  return(list(sum(result) / M, result));
}

historicallyAccurate <- function() {
  return(as.double(avarage(1000, 1000)[1]));
}
