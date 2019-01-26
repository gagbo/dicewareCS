# Diceware in C#

[![Build Status](https://travis-ci.com/gagbo/dicewareCS.svg?branch=master)](https://travis-ci.com/gagbo/dicewareCS)

## Disclaimer
This is a toy project, just to make myself at ease with C#.

Nothing is stable (moving from .NET Core to .NET Framework is in the list of stuff that will happen to the project). Do not expect this project to be your go-to solution at all.

I'll probably add weird tests and I'm still not sure about how to use CI/CD to produce production artifacts. **You've been warned.**

## Goal

This project run an executable which produces strong passwords using the diceword method.

## References

For the algorithm, and the words list I am targeting this [paper](http://weber.fi.eu.org/index.shtml.en#projects)

## Why Diceware ?

Diceware method for generating passwords is really nice and fun (I like
throwing dice), and I would like to use it to generate passwords on the fly for
the occasions where I don't have the time to actually do the full method (quick
sign up on a site I'll probably visit only once).

## Reinventing the wheel

Diceware is simple enough so I can implement it in my own way, so here I am.

There are probably a lot of diceware implementations in the wild

I advise you to run the dice or
trust these other guys, since crypto is not my forte (I know I have to use
a cryptographically validated number gen, but it's still pseudo-random; and that's pretty much it, this command line tool does not
protect you from snooping eyes or other infections/memory watchers I do not
know of)
